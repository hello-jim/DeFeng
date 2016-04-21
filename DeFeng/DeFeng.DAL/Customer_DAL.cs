using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using System.Data.SqlClient;
using DeFeng.Common;
using DeFeng.Model.Global;
namespace DeFeng.DAL
{
    public class Customer_DAL
    {
        string sqlConn = "";
        public List<Customer> Search(Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                #region Search条件
                var houseMaxCount = Convert.ToInt32(CommonClass.GetSysConfig("houseMaxCount"));
                StringBuilder sqlBuilder = new StringBuilder();
                var search = new StringBuilder();//搜索条件
                var search2 = new StringBuilder();//子搜索条件
                List<string> districtList = new List<string>();
                if (customer.District != null)
                {
                    districtList = customer.District.Name.Split(',').ToList();
                    if (districtList[0] == "")
                    {
                        districtList.RemoveAt(0);
                    }
                }
                List<string> areaList = new List<string>();
                if (customer.Area != null)
                {
                    areaList = customer.Area.AreaName.Split(',').ToList();
                    if (areaList[0] == "")
                    {
                        areaList.RemoveAt(0);
                    }
                }

                List<SqlParameter> sqlParList = new List<SqlParameter>();
                var NullDate = new DateTime();
                #region 城区
                if (districtList.Count != 0)
                {
                    search.Append(" h.id IN(SELECT  ID FROM House WHERE ");
                    for (int i = 0; i < districtList.Count; i++)
                    {
                        var parName = string.Format("@district{0}", i);
                        if (i == 0)
                        {
                            search.Append(string.Format(" [district]={0}", parName));
                            search2.Append(string.Format(" [district]={0}", parName));
                        }
                        else
                        {
                            search.Append(string.Format(" OR [district]={0}", parName));
                            search2.Append(string.Format(" OR [district]={0}", parName));
                        }
                        sqlParList.Add(new SqlParameter(parName, Convert.ToInt32(districtList[i])));
                    }
                    search.Append(") AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 片区
                if (areaList.Count != 0)
                {
                    for (int i = 0; i < areaList.Count; i++)
                    {
                        var parName = string.Format("@area{0}", i);
                        if (i == 0)
                        {
                            search.Append(string.Format(" [area]={0}", parName));
                            search2.Append(string.Format(" [area]={0}", parName));
                        }
                        else
                        {
                            search.Append(string.Format(" OR [area]={0}", parName));
                            search2.Append(string.Format(" OR [area]={0}", parName));
                        }
                        sqlParList.Add(new SqlParameter(parName, Convert.ToInt32(areaList[i])));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 房型
                //房型
                if (!(customer.RoomCount == 0 && customer.HallCount == 0 && customer.ToiletCount == 0))//当房型不为空时
                {
                    var str = "[roomCount]=@roomCount AND [hallCount]=@hallCount AND [toiletCount]=@toiletCount AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@roomCount", customer.RoomCount));
                    sqlParList.Add(new SqlParameter("@hallCount", customer.HallCount));
                    sqlParList.Add(new SqlParameter("@toiletCount", customer.ToiletCount));
                }
                #endregion

                #region 代理开始日期
                if (customer.EntrustStartDate != NullDate && customer.EntrustStartDate < DateTime.Now)
                {
                    var day = (DateTime.Now - customer.EntrustStartDate).Days;
                    var str = string.Format("[proxyStartDate]>=GETDATE()-@proxyStartDate AND ");
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@proxyStartDate", day));
                }
                #endregion

                #region 房屋状态
                if (customer.CustomerStatus != null)
                {
                    var str = "[houseStatus]=@houseStatus AND ";
                    search.Append(str);
                    search2.Append(str);
                    //sqlParList.Add(new SqlParameter("@houseStatus", customer.CustomerStatus.ID));
                }
                #endregion

                #region 房源品质
                //if (customer.CustomerQuality != null)
                //{
                //    var str = "[houseQuality]=@houseQuality AND ";
                //    search.Append(str);
                //    search2.Append(str);
                //  //  sqlParList.Add(new SqlParameter("@houseQuality", customer.CustomerQuality.ID));
                //}
                #endregion

                #region 交易类型
                if (customer.CustomerTransactionType != null)
                {
                    var str = "([transactionType]=@transactionType OR [transactionType]=3) AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@transactionType", customer.CustomerTransactionType.ID));
                }
                #endregion

                #region 房屋用途
                if (customer.HouseUseType != null)
                {
                    var str = "[houseUseType]=@houseUseType AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseUseType", customer.HouseUseType.ID));
                }
                #endregion

                #region 房屋类型
                if (customer.HouseType != null)
                {
                    var str = "[houseUseType]=@houseUseType AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseUseType", customer.HouseType.ID));
                }
                #endregion

                #region 房屋朝向
                if (customer.Orientation != null)
                {
                    var str = "[orientation]=@orientation AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@orientation", customer.Orientation.ID));
                }
                #endregion

                #region 价格
                if (customer.Price != 0 || customer.Price != 0)
                {
                    search.Append("[saleTotalPrice] >=@salePriceFrom");
                    search2.Append("[saleTotalPrice] >=@salePriceFrom");
                    sqlParList.Add(new SqlParameter("@salePriceFrom", customer.Price));
                    if (customer.Price != 0)
                    {
                        search.Append(" AND [saleTotalPrice] <=@salePriceTo");
                        search2.Append(" AND [saleTotalPrice] <=@salePriceTo");
                        sqlParList.Add(new SqlParameter("@salePriceTo", customer.Price));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 面积
                if (customer.HouseSizeFrom != 0 || customer.HouseSizeTo != 0)
                {
                    search.Append("[houseSize] >=@houseSizeFrom");
                    search2.Append("[houseSize] >=@houseSizeFrom");
                    sqlParList.Add(new SqlParameter("@houseSizeFrom", customer.HouseSizeFrom));
                    if (customer.HouseSizeTo != 0)
                    {
                        search.Append(" AND [houseSize] <=@houseSizeTo");
                        search2.Append(" AND [houseSize] <=@houseSizeTo");
                        sqlParList.Add(new SqlParameter("@houseSizeTo", customer.HouseSizeTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 楼层
                if (customer.FloorFrom != 0 || customer.FloorTo != 0)
                {
                    search.Append("[floor] >=@floorFrom");
                    search2.Append("[floor] >=@floorFrom");
                    sqlParList.Add(new SqlParameter("@floorFrom", customer.FloorFrom));
                    if (customer.HouseSizeTo != 0)
                    {
                        search.Append(" AND [floor] <=@floorTo");
                        search2.Append(" AND [floor] <=@floorTo");
                        sqlParList.Add(new SqlParameter("@floorTo", customer.FloorTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 部门或者员工
                if (customer.Department != null || customer.CreateStaff != null)
                {
                    search.Append("[department] >=@department");
                    search2.Append("[department] >=@department");
                    sqlParList.Add(new SqlParameter("@department", customer.Department.ID));
                    if (customer.CreateStaff.ID != 0)
                    {
                        search.Append(" AND [staff] <=@staff");
                        search2.Append(" AND [staff] <=@staff");
                        sqlParList.Add(new SqlParameter("@staff", customer.CreateStaff.ID));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 配套
                #endregion

                #endregion
                var searchStr = search.ToString();
                var searchStr2 = search2.ToString();
                var sql = new StringBuilder();
                sql.Append("SELECT TOP {0} Count(*) OVER() AS totalHouseCount,CustomerDemand.item,CustomerDemand.ID AS cusDemandID,CustomerStatus.statusName,CustomerStatus.ID AS cusStatusID,CustomerTransactionType.typeName AS cTypeName,District.Id AS disID, District.DisName, Area.ID AS areaID, areaName, ResidentialDistrict.ID AS rdID, ResidentialDistrict.name AS rdName, address, TransactionType.ID AS transactionTypeID, transactionTypeName, Orientation.ID AS orientationID, orientationName, HouseUseType.ID AS useTypeID, HouseUseType.typeName AS useTypeName, HouseType.ID AS houseTypeID, HouseType.typeName AS houseTypeName, CustomerStatus.ID AS statusID, CustomerStatus.statusName,DecorationType.ID AS decorationTypeID, DecorationType.typeName AS decorationTypeName, HousePayType.ID AS housePayTypeID, HousePayType.typeName AS housePayTypeName, CommissionPayType.ID AS commissionPayTypeID, CommissionPayType.typeName AS commissionPayTypeName, Source.ID AS sourceID,Source.sourceName,");
                sql.Append("c.ID as cID,[customerName],[contacts],[customerPhone],[contactsPhone],[IDCard],[presentAddress],[customerDemand],[customerStatus],[customerQuality],[isPrivateCustomer],[isQualityCustomer],[roomCount],[hallCount],[toiletCount],[entrustStartDate],[houseSize],[housePrice],[supporting],[entrustOverDate],[remarks],c.createDate, c.lastUpdateDate ");
                sql.Append("FROM [Customer] AS c,[District],[Area],[ResidentialDistrict],[CustomerDemand],[CustomerStatus],[CustomerTransactionType],[HouseUseType],[HouseType],[Source],[Grade],[Intention],[Nationality],[Orientation],[DecorationType],[HousePayType],[CommissionPayType] WHERE ");
                sql.Append(" h.district = District.Id AND h.residentialDistrict = ResidentialDistrict.ID AND  h.area = Area.ID AND h.customerDemand h.customerTransactionType = CustomerTransactionType.ID AND  h.houseUseType = HouseUseType.ID AND h.houseType = HouseType.ID AND h.source = Source.ID AND h.houseStatus = HouseStatus.ID AND h.taxPayType = TaxPayType.ID AND ");
                sql.Append("h.decorationType = DecorationType.ID AND h.houseDocumentType = HouseDocumentType.ID AND h.housePayType = HousePayType.ID AND h.commissionPayType = CommissionPayType.ID AND h.lookHouseType = LookHouseType.ID AND h.orientation = Orientation.ID AND ");
                sql.Append(string.Format("AND {1} h.ID NOT IN (SELECT TOP ({2} * ({3}-1)) ID FROM Customer  {4}) ", houseMaxCount, searchStr, houseMaxCount, customer.PageIndex, searchStr2 != "" ? (" WHERE " + (searchStr2.Substring(0, searchStr2.LastIndexOf("AND")))) : "")); 
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString(), sqlParList.ToArray());
                while (result.Read())
                {
                    var obj = new Customer();
                    obj.ID = Convert.ToInt32(result["cID"]);
                    obj.CustomerName = Convert.ToString(result["customerName"]);
                    obj.Contacts = Convert.ToString(result["contacts"]);
                    obj.ContactsPhone = Convert.ToString(result["contactsPhone"]);
                    obj.IdCard = Convert.ToString(result["IDCard"]);
                    obj.PresentAddress = Convert.ToString(result["presentAddress"]);
                    obj.CustomerDemand = new CustomerDemand
                    {
                        ID = Convert.ToInt32(result["cusDemandID"]),
                        Item = Convert.ToString(result["item"])
                    };
                    obj.CustomerStatus = new CustomerStatus
                    {
                        ID = Convert.ToInt32(result["cusStatusID"]),
                        StatusName = Convert.ToString(result["statusName"])
                    };
                    obj.CustomerTransactionType = new CustomerTransactionType
                    {
                        TypeName = Convert.ToString(result["cTypeName"])
                    };
                    obj.IsPrivateCustomer = Convert.ToBoolean(result["isPrivateCustomer"]);
                    obj.IsQualityCustomer = Convert.ToBoolean(result["isQualityCustomer"]);
                    obj.IsPubliceCustomer = Convert.ToBoolean(result["isPubliceCustomer"]);
                    obj.District = new District
                    {
                        ID = Convert.ToInt32(result["disID"]),
                        Name = Convert.ToString(result["DisName"])
                    };
                    obj.Area = new Area
                    {
                        ID = Convert.ToInt32(result["areaID"]),
                        AreaName = Convert.ToString(result["areaName"])
                    };
                    obj.Position = Convert.ToString(result["position"]);
                    obj.HouseUseType = new HouseUseType
                    {
                        ID = Convert.ToInt32(result["useTypeID"]),
                        TypeName = Convert.ToString(result["useTypeName"])
                    };
                    obj.HouseType = new HouseType
                    {
                        ID = Convert.ToInt32(result["houseTypeID"]),
                        TypeName = Convert.ToString(result["houseTypeName"])
                    };
                    obj.RoomCount = Convert.ToInt32(result["roomCount"]);
                    obj.HallCount = Convert.ToInt32(result["hallCount"]);
                    obj.ToiletCount = Convert.ToInt32(result["toiletCount"]);
                    obj.BalconyCount = Convert.ToInt32(result["balconyCount"]);
                    obj.EntrustStartDate = Convert.ToDateTime(result["entrustStartDate"]);
                    obj.HouseSize = Convert.ToSingle(result["houseSize"]);
                    obj.Price = Convert.ToDecimal(result["price"]);
                    obj.Source = new Source
                    {
                        ID = Convert.ToInt32(result["sourceID"]),
                        SourceName = Convert.ToString(result["sourceName"])
                    };
                    customerList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return customerList;
        }

        /// <summary>
        /// 房配客
        /// </summary>
        /// <returns></returns>
        public List<Customer> HouseMatchCustomer(House house)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                #region 搜索条件
                var search = new StringBuilder();
                var sqlPars = new List<SqlParameter>();
                #region 交易
                if (house.TransactionType != null)
                {
                    search.Append(" transactionType=@transactionType AND ");
                    sqlPars.Add(new SqlParameter("@transactionType", house.TransactionType.ID));
                }
                #endregion

                #region 城区
                if (house.District != null)
                {
                    search.Append(" district=@district AND ");
                    sqlPars.Add(new SqlParameter("@district", house.District.ID));
                }
                #endregion

                #region 片区
                if (house.Area != null)
                {
                    search.Append(" area=@area AND ");
                    sqlPars.Add(new SqlParameter("@area", house.Area.ID));
                }
                #endregion

                #region 楼盘
                if (house.ResidentialDistrict != null)
                {
                    search.Append(" residentialDistrict=@residentialDistrict AND ");
                    sqlPars.Add(new SqlParameter("@residentialDistrict", house.ResidentialDistrict.ID));
                }
                #endregion

                #region 用途
                if (house.HouseUseType != null)
                {
                    search.Append(" houseUseType=@houseUseType AND ");
                    sqlPars.Add(new SqlParameter("@houseUseType", house.HouseUseType.ID));
                }
                #endregion

                #region 房型
                if (house.RoomCount != 0)
                {

                }
                #endregion

                #region 价格
                if (house.SaleTotalPrice != 0)
                {
                    search.Append(" price=@price AND ");
                    sqlPars.Add(new SqlParameter("@price", house.SaleTotalPrice));
                }
                #endregion

                #region 面积
                if (house.HouseSize != 0)
                {
                    search.Append(" price=@price AND ");
                    sqlPars.Add(new SqlParameter("@price", house.HouseSize));
                }
                #endregion

                var sql = search.ToString();
                sql = string.Format("SELECT * FROM Customer WHERE {0} c.ID NOT IN(SELECT * FROM Customer)");
                #endregion


                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, "", sqlPars.ToArray());
                while (result.Read())
                {
                    Customer obj = new Customer();
                    customerList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return customerList;
        }
    }
}
