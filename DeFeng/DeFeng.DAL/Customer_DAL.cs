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
        string sqlConn = Common.CommonClass.GetSysConfig("DeFengDBConStr");
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
                    search.Append(" c.id IN(SELECT  ID FROM Customer WHERE ");
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

                #region 委托开始日期
                if (customer.EntrustStartDate != NullDate && customer.EntrustStartDate < DateTime.Now)
                {
                    var day = (DateTime.Now - customer.EntrustStartDate).Days;
                    var str = string.Format("[entrustStartDate]>=GETDATE()-@entrustStartDate AND ");
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@entrustStartDate", day));
                }
                #endregion

                #region 房屋状态
                if (customer.CustomerStatus != null)
                {
                    var str = "[customerStatus]=@customerStatus AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@customerStatus", customer.CustomerStatus.ID));
                }
                #endregion

                #region 私客
                if (customer.IsPrivateCustomer)
                {
                    var str = "[isPrivateCustomer]=@isPrivateCustomer AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@isPrivateCustomer", customer.IsPrivateCustomer));
                }
                #endregion

                #region 公客
                if (customer.IsPubliceCustomer)
                {
                    var str = "[isPubliceCustomer]=@isPubliceCustomer AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@isPubliceCustomer", customer.IsPubliceCustomer));
                }
                #endregion

                #region 优质客
                if (customer.IsQualityCustomer)
                {
                    var str = "[isQualityCustomer]=@isQualityCustomer AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@isQualityCustomer", customer.IsQualityCustomer));
                }
                #endregion

                #region 交易类型
                if (customer.CustomerTransactionType != null)
                {
                    var str = "([customerTransactionType]=@customerTransactionType OR [customerTransactionType]=3) AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@customerTransactionType", customer.CustomerTransactionType.ID));
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
                if (customer.PriceFrom != 0 || customer.PriceTo != 0)
                {
                    search.Append("[priceFrom] >=@priceFrom");
                    search2.Append("[priceFrom] >=@priceFrom");
                    sqlParList.Add(new SqlParameter("@priceFrom", customer.PriceFrom));
                    if (customer.PriceTo != 0)
                    {
                        search.Append(" AND [priceTo] <=@priceTo");
                        search2.Append(" AND [priceTo] <=@priceTo");
                        sqlParList.Add(new SqlParameter("@priceTo", customer.PriceTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 面积
                if (customer.HouseSizeFrom != 0 || customer.HouseSizeTo != 0)
                {
                    search.Append("[houseSizeFrom] >=@houseSizeFrom");
                    search2.Append("[houseSizeFrom] >=@houseSizeFrom");
                    sqlParList.Add(new SqlParameter("@houseSizeFrom", customer.HouseSizeFrom));
                    if (customer.HouseSizeTo != 0)
                    {
                        search.Append(" AND [houseSizeTo] <=@houseSizeTo");
                        search2.Append(" AND [houseSizeTo] <=@houseSizeTo");
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
                sql.Append(string.Format("SELECT * FROM (SELECT TOP {0} Count(*) OVER() AS totalCustomerCount,CustomerDemand.item,CustomerDemand.ID AS cusDemandID,CustomerTransactionType.ID AS customerTransactionTypeID,CustomerTransactionType.typeName AS cTypeName,District.Id AS disID, District.DisName, Area.ID AS areaID, areaName, ResidentialDistrict.ID AS rdID, ResidentialDistrict.name AS rdName, [address], Orientation.ID AS orientationID,orientationName,Country.ID AS countryID,chineseName, HouseUseType.ID AS useTypeID, HouseUseType.typeName AS useTypeName, HouseType.ID AS houseTypeID, HouseType.typeName AS houseTypeName, CustomerStatus.ID AS statusID, CustomerStatus.statusName,DecorationType.ID AS decorationTypeID, DecorationType.typeName AS decorationTypeName, HousePayType.ID AS housePayTypeID, HousePayType.typeName AS housePayTypeName, CommissionPayType.ID AS commissionPayTypeID, CommissionPayType.typeName AS commissionPayTypeName, Source.ID AS sourceID,Source.sourceName, Grade.ID AS gradeID,gradeName,Intention.ID AS intentionID,intentionName,EntrustType.ID AS entrustTypeID,EntrustType.typeName AS entrustTypeName,CustomerType.ID AS customerTypeID,CustomerType.typeName AS customerTypeName,OfficeLevel.ID AS officeLevelID,levelName,ShopLocation.ID AS shopLocationID,ShopLocation.Item AS shopLocationItem,LandPlan.ID AS landPlanID,planName,CarPark.ID AS carParkID,CarPark.name AS carParkName,Wall.ID AS wallID,Wall.item AS wallItem,ShopArea.ID AS shopAreaID,shopAreaName,LandType.ID AS landTypeID,LandType.typeName AS landTypeName,City.CityID,CityName,", houseMaxCount));
                sql.Append("c.ID as cID,[customerName],[contacts],[customerPhone],[contactsPhone],[IDCard],[presentAddress],[customerDemand],[customerStatus],[isPrivateCustomer],[isQualityCustomer],[isPubliceCustomer],[position],[roomCount],[hallCount],[toiletCount],[balconyCount],[entrustStartDate],[houseSizeFrom],[houseSizeTo],[priceFrom],[priceTo],[supporting],[remarks],c.createDate, c.lastUpdateDate,c.lastFollowDate ");
                sql.Append("FROM [Customer] AS c ");
                sql.Append("LEFT JOIN [City] ON c.city=[City].CityID ");
                sql.Append("LEFT JOIN [District] ON c.district=[District].ID ");
                sql.Append("LEFT JOIN [Area] ON c.area=[Area].ID ");
                sql.Append("LEFT JOIN [ResidentialDistrict] ON c.residentialDistrict=[ResidentialDistrict].ID ");
                sql.Append("LEFT JOIN [CustomerDemand] ON c.customerDemand=[CustomerDemand].ID ");
                sql.Append("LEFT JOIN [CustomerStatus] ON c.customerStatus=[CustomerStatus].ID ");
                sql.Append("LEFT JOIN [CustomerTransactionType] ON c.customerTransactionType=[CustomerTransactionType].ID ");
                sql.Append("LEFT JOIN [HouseUseType] ON c.houseUseType=[HouseUseType].ID ");
                sql.Append("LEFT JOIN [HouseType] ON c.houseType=[HouseType].ID ");
                sql.Append("LEFT JOIN [Source] ON c.source=[Source].ID ");
                sql.Append("LEFT JOIN [Grade] ON c.grade=[Grade].ID ");
                sql.Append("LEFT JOIN [Intention] ON c.intention=[Intention].ID ");
                sql.Append("LEFT JOIN [Country] ON c.nationality=[Country].ID ");
                sql.Append("LEFT JOIN [Orientation] ON c.orientation=[Orientation].ID ");
                sql.Append("LEFT JOIN [DecorationType] ON c.decorationType=[DecorationType].ID ");
                sql.Append("LEFT JOIN [HousePayType] ON c.housePayType=[HousePayType].ID ");
                sql.Append("LEFT JOIN [CommissionPayType] ON c.commissionPayType=[CommissionPayType].ID ");
                sql.Append("LEFT JOIN [EntrustType] ON c.entrustType=[EntrustType].ID ");
                sql.Append("LEFT JOIN [CustomerType] ON c.customerType=[CustomerType].ID ");
                sql.Append("LEFT JOIN [OfficeLevel] ON c.officeLevel=[OfficeLevel].ID ");
                sql.Append("LEFT JOIN [ShopLocation] ON c.shopLocation=[ShopLocation].ID ");
                sql.Append("LEFT JOIN [LandPlan] ON c.landPlan=[LandPlan].ID ");
                sql.Append("LEFT JOIN [CarPark] ON c.carPark=[CarPark].ID ");
                sql.Append("LEFT JOIN [Wall] ON c.wall=[Wall].ID ");
                sql.Append("LEFT JOIN [ShopArea] ON c.shopArea=[ShopArea].ID ");
                sql.Append("LEFT JOIN [LandType] ON c.landType=[LandType].ID ");
                sql.Append(string.Format("WHERE {0} c.ID NOT IN (SELECT TOP ({1} * ({2}-1)) ID FROM Customer  {3}) ", searchStr, houseMaxCount, customer.PageIndex, searchStr2 != "" ? (" WHERE " + (searchStr2.Substring(0, searchStr2.LastIndexOf("AND")))) : ""));
                sql.Append(" ORDER BY c.ID)temp ORDER BY temp.entrustStartDate");
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
                        ID = Convert.ToInt32(Convert.IsDBNull(result["cusDemandID"]) ? 0 : result["cusDemandID"]),
                        Item = Convert.ToString(Convert.IsDBNull(result["item"]) ? "" : result["item"])
                    };
                    obj.CustomerStatus = new CustomerStatus
                    {
                        ID = Convert.ToInt32(Convert.IsDBNull(result["statusID"]) ? 0 : result["statusID"]),
                        StatusName = Convert.ToString(Convert.IsDBNull(result["statusName"]) ? "" : result["statusName"])
                    };
                    obj.CustomerTransactionType = new CustomerTransactionType
                    {
                        ID = Convert.IsDBNull(result["customerTransactionTypeID"]) ? 0 : Convert.ToInt32(result["customerTransactionTypeID"]),
                        TypeName = Convert.IsDBNull(result["cTypeName"]) ? "" : Convert.ToString(result["cTypeName"])
                    };
                    obj.IsPrivateCustomer = Convert.ToBoolean(result["isPrivateCustomer"]);
                    obj.IsQualityCustomer = Convert.ToBoolean(result["isQualityCustomer"]);
                    obj.IsPubliceCustomer = Convert.ToBoolean(result["isPubliceCustomer"]);
                    obj.District = new District
                    {
                        ID = Convert.IsDBNull(result["disID"]) ? 0 : Convert.ToInt32(result["disID"]),
                        Name = Convert.IsDBNull(result["DisName"]) ? "" : Convert.ToString(result["DisName"])
                    };
                    obj.Area = new Area
                    {
                        ID = Convert.IsDBNull(result["areaID"]) ? 0 : Convert.ToInt32(result["areaID"]),
                        AreaName = Convert.IsDBNull(result["areaName"]) ? "" : Convert.ToString(result["areaName"])
                    };
                    obj.ResidentialDistrict = new ResidentialDistrict
                    {
                        ID = Convert.IsDBNull(result["rdID"]) ? 0 : Convert.ToInt32(result["rdID"]),
                        Name = Convert.IsDBNull(result["rdName"]) ? "" : Convert.ToString(result["rdName"]),
                    };
                    obj.Position = Convert.ToString(result["position"]);
                    obj.HouseUseType = new HouseUseType
                    {
                        ID = Convert.IsDBNull(result["useTypeID"]) ? 0 : Convert.ToInt32(result["useTypeID"]),
                        TypeName = Convert.IsDBNull(result["useTypeName"]) ? "" : Convert.ToString(result["useTypeName"])
                    };
                    obj.HouseType = new HouseType
                    {
                        ID = Convert.IsDBNull(result["houseTypeID"]) ? 0 : Convert.ToInt32(result["houseTypeID"]),
                        TypeName = Convert.IsDBNull(result["houseTypeName"]) ? "" : Convert.ToString(result["houseTypeName"])
                    };
                    obj.RoomCount = Convert.ToInt32(result["roomCount"]);
                    obj.HallCount = Convert.ToInt32(result["hallCount"]);
                    obj.ToiletCount = Convert.ToInt32(result["toiletCount"]);
                    obj.BalconyCount = Convert.ToInt32(result["balconyCount"]);
                    obj.EntrustStartDate = Convert.ToDateTime(result["entrustStartDate"]);
                    obj.HouseSizeFrom = Convert.IsDBNull(result["houseSizeFrom"]) ? 0 : Convert.ToSingle(result["houseSizeFrom"]);
                    obj.HouseSizeTo = Convert.IsDBNull(result["houseSizeTo"]) ? 0 : Convert.ToSingle(result["houseSizeTo"]);
                    obj.PriceFrom = Convert.IsDBNull(result["priceFrom"]) ? 0 : Convert.ToDecimal(result["priceFrom"]);
                    obj.PriceTo = Convert.IsDBNull(result["priceTo"]) ? 0 : Convert.ToDecimal(result["priceTo"]);
                    obj.Source = new Source
                    {
                        ID = Convert.IsDBNull(result["sourceID"]) ? 0 : Convert.ToInt32(result["sourceID"]),
                        SourceName = Convert.IsDBNull(result["sourceName"]) ? "" : Convert.ToString(result["sourceName"])
                    };
                    obj.Grade = new Grade
                    {
                        ID = Convert.IsDBNull(result["gradeID"]) ? 0 : Convert.ToInt32(result["gradeID"]),
                        GradeName = Convert.IsDBNull(result["gradeName"]) ? "" : Convert.ToString(result["gradeName"])
                    };
                    obj.Intention = new Intention
                    {
                        ID = Convert.IsDBNull(result["intentionID"]) ? 0 : Convert.ToInt32(result["intentionID"]),
                        IntentionName = Convert.IsDBNull(result["intentionName"]) ? "" : Convert.ToString(result["intentionName"])
                    };
                    obj.Orientation = new Orientation
                    {
                        ID = Convert.IsDBNull(result["orientationID"]) ? 0 : Convert.ToInt32(result["orientationID"]),
                        OrientationName = Convert.IsDBNull(result["orientationName"]) ? "" : Convert.ToString(result["orientationName"])
                    };
                    obj.DecorationType = new DecorationType
                    {
                        ID = Convert.IsDBNull(result["decorationTypeID"]) ? 0 : Convert.ToInt32(result["decorationTypeID"]),
                        TypeName = Convert.IsDBNull(result["decorationTypeName"]) ? "" : Convert.ToString(result["decorationTypeName"])
                    };
                    obj.HousePayType = new HousePayType
                    {
                        ID = Convert.IsDBNull(result["housePayTypeID"]) ? 0 : Convert.ToInt32(result["housePayTypeID"]),
                        TypeName = Convert.IsDBNull(result["housePayTypeName"]) ? "" : Convert.ToString(result["housePayTypeName"])
                    };
                    obj.CommissionPayType = new CommissionPayType
                    {
                        ID = Convert.IsDBNull(result["commissionPayTypeID"]) ? 0 : Convert.ToInt32(result["commissionPayTypeID"]),
                        TypeName = Convert.IsDBNull(result["commissionPayTypeName"]) ? "" : Convert.ToString(result["commissionPayTypeName"])
                    };
                    obj.EntrustType = new EntrustType
                    {
                        ID = Convert.IsDBNull(result["entrustTypeID"]) ? 0 : Convert.ToInt32(result["entrustTypeID"]),
                        TypeName = Convert.IsDBNull(result["entrustTypeName"]) ? "" : Convert.ToString(result["entrustTypeName"])
                    };
                    obj.CustomerType = new CustomerType
                    {
                        ID = Convert.IsDBNull(result["customerTypeID"]) ? 0 : Convert.ToInt32(result["customerTypeID"]),
                        TypeName = Convert.IsDBNull(result["customerTypeName"]) ? "" : Convert.ToString(result["customerTypeName"])
                    };
                    obj.OfficeLevel = new OfficeLevel
                    {
                        ID = Convert.IsDBNull(result["officeLevelID"]) ? 0 : Convert.ToInt32(result["officeLevelID"]),
                        LevelName = Convert.IsDBNull(result["levelName"]) ? "" : Convert.ToString(result["levelName"])
                    };
                    obj.ShopLocation = new ShopLocation
                    {
                        ID = Convert.IsDBNull(result["shopLocationID"]) ? 0 : Convert.ToInt32(result["shopLocationID"]),
                        Item = Convert.IsDBNull(result["shopLocationItem"]) ? "" : Convert.ToString(result["shopLocationItem"])
                    };
                    obj.LandPlan = new LandPlan
                    {
                        ID = Convert.IsDBNull(result["landPlanID"]) ? 0 : Convert.ToInt32(result["landPlanID"]),
                        PlanName = Convert.IsDBNull(result["planName"]) ? "" : Convert.ToString(result["planName"])
                    };
                    obj.CarPark = new CarPark
                    {
                        ID = Convert.IsDBNull(result["carParkID"]) ? 0 : Convert.ToInt32(result["carParkID"]),
                        Name = Convert.IsDBNull(result["carParkName"]) ? "" : Convert.ToString(result["carParkName"])
                    };
                    obj.Wall = new Wall
                    {
                        ID = Convert.IsDBNull(result["wallID"]) ? 0 : Convert.ToInt32(result["wallID"]),
                        Item = Convert.IsDBNull(result["wallItem"]) ? "" : Convert.ToString(result["wallItem"])
                    };
                    obj.ShopArea = new ShopArea
                    {
                        ID = Convert.IsDBNull(result["shopAreaID"]) ? 0 : Convert.ToInt32(result["shopAreaID"]),
                        ShopAreaName = Convert.IsDBNull(result["shopAreaName"]) ? "" : Convert.ToString(result["shopAreaName"])
                    };
                    obj.Nationality = new Country
                    {
                        ID = Convert.IsDBNull(result["countryID"]) ? 0 : Convert.ToInt32(result["countryID"]),
                        ChineseName = Convert.IsDBNull(result["chineseName"]) ? "" : Convert.ToString(result["chineseName"])
                    };
                    obj.LandType = new LandType
                    {
                        ID = Convert.IsDBNull(result["landTypeID"]) ? 0 : Convert.ToInt32(result["landTypeID"]),
                        TypeName = Convert.IsDBNull(result["landTypeName"]) ? "" : Convert.ToString(result["landTypeName"])
                    };
                    obj.City = new City
                    {
                        ID = Convert.IsDBNull(result["CityID"]) ? 0 : Convert.ToInt32(result["CityID"]),
                        Name = Convert.IsDBNull(result["CityName"]) ? "" : Convert.ToString(result["CityName"])
                    };
                    obj.Remarks = Convert.IsDBNull(result["remarks"]) ? "" : Convert.ToString(result["remarks"]);
                    obj.LastFollowDate = Convert.ToDateTime(result["lastFollowDate"]);
                    obj.TotalCustomerCount = Convert.ToInt32(result["totalCustomerCount"]);
                    obj.PageIndex = customer.PageIndex;
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

        public int AddCutomer(Customer customer)
        {
            var result = 0;
            try
            {
                var sql = "INSERT INTO Customer([customerName],[contacts],[customerPhone],[contactsPhone],[customerMobile],[IDCard],[presentAddress],[district],[area],[residentialDistrict] ,[customerDemand],[customerStatus],[customerTransactionType],[isPrivateCustomer],[isQualityCustomer],[isPubliceCustomer],[position],[houseUseType],[houseType],[roomCount],[hallCount],[toiletCount],[balconyCount],[entrustStartDate],[houseSizeFrom],[houseSizeTo],[priceFrom],[priceTo],[source],[grade] ,[intention],[nationality] ,[floor],[orientation],[decorationType],[housePayType],[supporting],[commissionPayType],[entrustType] ,[customerType],[shopLocation],[industry],[totalFloor],[wall],[electricity],[park],[landType],[OfficeLevel],[workerCount],[dormCount],[officeCount],[clearingCount],[current],[carPark],[landPlan],[remarks],[createDate],[lastFollowDate],[lastUpdateStaff],[lastUpdateDate]) VALUES(@customerName,@contacts,@customerPhone,@contactsPhone,@customerMobile,@IDCard,@presentAddress,@district,@area,@residentialDistrict ,@customerDemand,@customerStatus,@customerTransactionType,@isPrivateCustomer,@isQualityCustomer,@isPubliceCustomer,@position,@houseUseType,@houseType,@roomCount,@hallCount,@toiletCount,@balconyCount,@entrustStartDate,@houseSizeFrom,@houseSizeTo,@priceFrom,@priceTo,@source,@grade ,@intention,@nationality,@floor,@orientation,@decorationType,@housePayType,@supporting,@commissionPayType,@entrustType ,@customerType,@shopLocation,@industry,@totalFloor,@wall,@electricity,@park,@landType,@OfficeLevel,@workerCount,@dormCount,@officeCount,@clearingCount,@current,@carPark,@landPlan,@remarks,@createDate,@lastFollowDate,@lastUpdateStaff,@lastUpdateDate)";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@customerName", customer.CustomerName));
                sqlPars.Add(new SqlParameter("@contacts", customer.Contacts));
                sqlPars.Add(new SqlParameter("@customerPhone", customer.CustomerPhone));
                sqlPars.Add(new SqlParameter("@contactsPhone", ""));
                sqlPars.Add(new SqlParameter("@customerMobile", ""));
                sqlPars.Add(new SqlParameter("@IDCard", customer.IdCard));
                sqlPars.Add(new SqlParameter("@presentAddress", customer.PresentAddress));
                sqlPars.Add(new SqlParameter("@district", customer.District.ID));
                sqlPars.Add(new SqlParameter("@area", customer.Area.ID));
                sqlPars.Add(new SqlParameter("@residentialDistrict", customer.ResidentialDistrict.ID));
                sqlPars.Add(new SqlParameter("@customerDemand", customer.CustomerDemand.ID));
                sqlPars.Add(new SqlParameter("@customerStatus", customer.CustomerStatus.ID));
                sqlPars.Add(new SqlParameter("@customerTransactionType", customer.CustomerTransactionType.ID));
                sqlPars.Add(new SqlParameter("@isPrivateCustomer", customer.IsPrivateCustomer));
                sqlPars.Add(new SqlParameter("@isQualityCustomer", customer.IsQualityCustomer));
                sqlPars.Add(new SqlParameter("@isPubliceCustomer", customer.IsPubliceCustomer));
                sqlPars.Add(new SqlParameter("@position", ""));
                sqlPars.Add(new SqlParameter("@houseUseType", customer.HouseUseType.ID));
                sqlPars.Add(new SqlParameter("@houseType", customer.HouseType.ID));
                sqlPars.Add(new SqlParameter("@roomCount", customer.RoomCount));
                sqlPars.Add(new SqlParameter("@hallCount", customer.HallCount));
                sqlPars.Add(new SqlParameter("@toiletCount", customer.ToiletCount));
                sqlPars.Add(new SqlParameter("@balconyCount", customer.BalconyCount));
                sqlPars.Add(new SqlParameter("@entrustStartDate", customer.EntrustStartDate));
                sqlPars.Add(new SqlParameter("@houseSizeFrom", customer.HouseSizeFrom));
                sqlPars.Add(new SqlParameter("@houseSizeTo", customer.HouseSizeTo));
                sqlPars.Add(new SqlParameter("@priceFrom", customer.PriceFrom));
                sqlPars.Add(new SqlParameter("@priceTo", customer.PriceTo));
                sqlPars.Add(new SqlParameter("@source", customer.Source.ID));
                sqlPars.Add(new SqlParameter("@grade", customer.Grade.ID));
                sqlPars.Add(new SqlParameter("@intention", customer.Intention.ID));
                sqlPars.Add(new SqlParameter("@nationality", customer.Nationality.ID));
                // sqlPars.Add(new SqlParameter("@entrustOverDate", customer.EntrustOverDate));
                sqlPars.Add(new SqlParameter("@floor", customer.Floor));
                sqlPars.Add(new SqlParameter("@orientation", customer.Orientation.ID));
                sqlPars.Add(new SqlParameter("@decorationType", customer.DecorationType.ID));
                sqlPars.Add(new SqlParameter("@housePayType", customer.HousePayType.ID));
                sqlPars.Add(new SqlParameter("@supporting", customer.Supporting));
                sqlPars.Add(new SqlParameter("@commissionPayType", customer.CommissionPayType.ID));
                sqlPars.Add(new SqlParameter("@entrustType", customer.EntrustType.ID));
                sqlPars.Add(new SqlParameter("@customerType", customer.CustomerType.ID));
                sqlPars.Add(new SqlParameter("@shopLocation", customer.ShopLocation.ID));
                sqlPars.Add(new SqlParameter("@industry", customer.Industry));
                sqlPars.Add(new SqlParameter("@totalFloor", customer.TotalFloor));
                sqlPars.Add(new SqlParameter("@wall", customer.Wall.ID));
                sqlPars.Add(new SqlParameter("@electricity", customer.Electricity));
                sqlPars.Add(new SqlParameter("@park", customer.Park));
                sqlPars.Add(new SqlParameter("@landType", customer.LandType.ID));
                sqlPars.Add(new SqlParameter("@OfficeLevel", customer.OfficeLevel.ID));
                sqlPars.Add(new SqlParameter("@workerCount", customer.WorkerCount));
                sqlPars.Add(new SqlParameter("@dormCount", customer.DormCount));
                sqlPars.Add(new SqlParameter("@officeCount", customer.OfficeCount));
                sqlPars.Add(new SqlParameter("@clearingCount", customer.ClearingCount));
                sqlPars.Add(new SqlParameter("@current", customer.Current.ID));
                sqlPars.Add(new SqlParameter("@carPark", customer.CarPark.ID));
                sqlPars.Add(new SqlParameter("@landPlan", customer.LandPlan.ID));
                sqlPars.Add(new SqlParameter("@remarks", customer.Remarks));
                // sqlPars.Add(new SqlParameter("@department", customer.Department.ID));
                // sqlPars.Add(new SqlParameter("@createStaff", customer.CreateStaff.ID));
                sqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastFollowDate", ""));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", "0"));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int UpdateCustomer(Customer customer)
        {
            var result = 0;
            try
            {
                var sql = "UPDATE Customer SET [customerName]=@customerName,[contacts]=@contacts,[customerPhone]=@customerPhone,[contactsPhone]=@contactsPhone,[customerMobile]=@customerMobile,[IDCard]=@IDCard,[presentAddress]=@presentAddress,[city]=@city,[district]=@district,[area]=@area,[residentialDistrict]=@residentialDistrict,[customerDemand]=@customerDemand,[customerStatus]=@customerStatus,[customerTransactionType]=@customerTransactionType,[isPrivateCustomer]=@isPrivateCustomer,[isQualityCustomer]=@isQualityCustomer,[isPubliceCustomer]=@isPubliceCustomer,[position]=@position,[houseUseType]=@houseUseType,[houseType]=@houseType,[roomCount]=@roomCount,[hallCount]=@hallCount,[toiletCount]=@toiletCount,[balconyCount]=@balconyCount,[houseSizeFrom]=@houseSizeFrom,[houseSizeTo]=@houseSizeTo,[priceFrom]=@priceFrom,[priceTo]=@priceTo,[source]=@source,[grade]=@grade ,[intention]=@intention,[nationality]=@nationality,[floor]=@floor,[orientation]=@orientation,[decorationType]=@decorationType,[housePayType]=@housePayType,[supporting]=@supporting,[commissionPayType]=@commissionPayType,[entrustType]=@entrustType ,[customerType]=@customerType,[shopLocation]=@shopLocation,[industry]=@industry,[totalFloor]=@totalFloor,[wall]=@wall,[electricity]=@electricity,[park]=@park,[landType]=@landType,[OfficeLevel]=@OfficeLevel,[workerCount]=@workerCount,[dormCount]=@dormCount,[officeCount]=@officeCount,[clearingCount]=@clearingCount,[current]=@current,[carPark]=@carPark,[landPlan]=@landPlan,[remarks]=@remarks,[lastUpdateStaff]=@lastUpdateStaff,[lastUpdateDate]=@lastUpdateDate  WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", customer.ID));
                sqlPars.Add(new SqlParameter("@customerName", customer.CustomerName));
                sqlPars.Add(new SqlParameter("@contacts", customer.Contacts));
                sqlPars.Add(new SqlParameter("@customerPhone", customer.CustomerPhone));
                sqlPars.Add(new SqlParameter("@contactsPhone", customer.ContactsPhone));
                sqlPars.Add(new SqlParameter("@customerMobile", ""));
                sqlPars.Add(new SqlParameter("@IDCard", customer.IdCard));
                sqlPars.Add(new SqlParameter("@presentAddress", customer.PresentAddress));
                sqlPars.Add(new SqlParameter("@city", customer.City.ID));
                sqlPars.Add(new SqlParameter("@district", customer.District.ID));
                sqlPars.Add(new SqlParameter("@area", customer.Area.ID));
                sqlPars.Add(new SqlParameter("@residentialDistrict", customer.ResidentialDistrict.ID));
                sqlPars.Add(new SqlParameter("@customerDemand", customer.CustomerDemand.ID));
                sqlPars.Add(new SqlParameter("@customerStatus", customer.CustomerStatus.ID));
                sqlPars.Add(new SqlParameter("@customerTransactionType", customer.CustomerTransactionType.ID));
                sqlPars.Add(new SqlParameter("@isPrivateCustomer", customer.IsPrivateCustomer));
                sqlPars.Add(new SqlParameter("@isQualityCustomer", customer.IsQualityCustomer));
                sqlPars.Add(new SqlParameter("@isPubliceCustomer", customer.IsPubliceCustomer));
                sqlPars.Add(new SqlParameter("@position", ""));
                sqlPars.Add(new SqlParameter("@houseUseType", customer.HouseUseType.ID));
                sqlPars.Add(new SqlParameter("@houseType", customer.HouseType.ID));
                sqlPars.Add(new SqlParameter("@roomCount", customer.RoomCount));
                sqlPars.Add(new SqlParameter("@hallCount", customer.HallCount));
                sqlPars.Add(new SqlParameter("@toiletCount", customer.ToiletCount));
                sqlPars.Add(new SqlParameter("@balconyCount", customer.BalconyCount));
                sqlPars.Add(new SqlParameter("@houseSizeFrom", customer.HouseSizeFrom));
                sqlPars.Add(new SqlParameter("@houseSizeTo", customer.HouseSizeTo));
                sqlPars.Add(new SqlParameter("@priceFrom", customer.PriceFrom));
                sqlPars.Add(new SqlParameter("@priceTo", customer.PriceTo));
                sqlPars.Add(new SqlParameter("@source", customer.Source.ID));
                sqlPars.Add(new SqlParameter("@grade", customer.Grade.ID));
                sqlPars.Add(new SqlParameter("@intention", customer.Intention.ID));
                sqlPars.Add(new SqlParameter("@nationality", customer.Nationality.ID));
                // sqlPars.Add(new SqlParameter("@entrustOverDate", customer.EntrustOverDate));
                sqlPars.Add(new SqlParameter("@floor", customer.Floor));
                sqlPars.Add(new SqlParameter("@orientation", customer.Orientation.ID));
                sqlPars.Add(new SqlParameter("@decorationType", customer.DecorationType.ID));
                sqlPars.Add(new SqlParameter("@housePayType", customer.HousePayType.ID));
                sqlPars.Add(new SqlParameter("@supporting", customer.Supporting));
                sqlPars.Add(new SqlParameter("@commissionPayType", customer.CommissionPayType.ID));
                sqlPars.Add(new SqlParameter("@entrustType", customer.EntrustType.ID));
                sqlPars.Add(new SqlParameter("@customerType", customer.CustomerType.ID));
                sqlPars.Add(new SqlParameter("@shopLocation", customer.ShopLocation.ID));
                sqlPars.Add(new SqlParameter("@industry", customer.Industry));
                sqlPars.Add(new SqlParameter("@totalFloor", customer.TotalFloor));
                sqlPars.Add(new SqlParameter("@wall", customer.Wall.ID));
                sqlPars.Add(new SqlParameter("@electricity", customer.Electricity));
                sqlPars.Add(new SqlParameter("@park", customer.Park));
                sqlPars.Add(new SqlParameter("@landType", customer.LandType.ID));
                sqlPars.Add(new SqlParameter("@OfficeLevel", customer.OfficeLevel.ID));
                sqlPars.Add(new SqlParameter("@workerCount", customer.WorkerCount));
                sqlPars.Add(new SqlParameter("@dormCount", customer.DormCount));
                sqlPars.Add(new SqlParameter("@officeCount", customer.OfficeCount));
                sqlPars.Add(new SqlParameter("@clearingCount", customer.ClearingCount));
                sqlPars.Add(new SqlParameter("@current", customer.Current.ID));
                sqlPars.Add(new SqlParameter("@carPark", customer.CarPark.ID));
                sqlPars.Add(new SqlParameter("@landPlan", customer.LandPlan.ID));
                sqlPars.Add(new SqlParameter("@remarks", customer.Remarks));
                // sqlPars.Add(new SqlParameter("@department", customer.Department.ID));
                // sqlPars.Add(new SqlParameter("@createStaff", customer.CreateStaff.ID));
                sqlPars.Add(new SqlParameter("@lastFollowDate", ""));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", "0"));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        
    }
}
