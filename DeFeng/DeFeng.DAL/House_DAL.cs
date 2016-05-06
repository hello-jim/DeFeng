using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Model;
using DeFeng.Model.Global;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class House_DAL
    {
        string sqlConn = Common.CommonClass.GetSysConfig("DeFengDBConStr");
        public List<House> SearchHouse(House house)
        {
            List<House> houseList = new List<House>();
            try
            {
                #region Search条件
                var houseMaxCount = Convert.ToInt32(CommonClass.GetSysConfig("houseMaxCount"));
                StringBuilder sqlBuilder = new StringBuilder();
                var search = new StringBuilder();//搜索条件
                var search2 = new StringBuilder();//子搜索条件
                List<string> districtList = new List<string>();
                if (house.District != null)
                {
                    districtList = house.District.Name.Split(',').ToList();
                    if (districtList[0] == "")
                    {
                        districtList.RemoveAt(0);
                    }
                }
                List<string> areaList = new List<string>();
                if (house.Area != null)
                {
                    areaList = house.Area.AreaName.Split(',').ToList();
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
                if (!(house.RoomCount == 0 && house.HallCount == 0 && house.ToiletCount == 0))//当房型不为空时
                {
                    var str = "[roomCount]=@roomCount AND [hallCount]=@hallCount AND [toiletCount]=@toiletCount AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@roomCount", house.RoomCount));
                    sqlParList.Add(new SqlParameter("@hallCount", house.HallCount));
                    sqlParList.Add(new SqlParameter("@toiletCount", house.ToiletCount));
                }
                #endregion

                #region 代理开始日期
                if (house.ProxyStartDate != NullDate && house.ProxyStartDate < DateTime.Now)
                {
                    var day = (DateTime.Now - house.ProxyStartDate).Days;
                    var str = string.Format("[proxyStartDate]>=GETDATE()-@proxyStartDate AND ");
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@proxyStartDate", day));
                }
                #endregion

                #region 房屋状态
                if (house.HouseStatus != null)
                {
                    var str = "[houseStatus]=@houseStatus AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseStatus", house.HouseStatus.ID));
                }
                #endregion

                #region 房源品质
                if (house.HouseQuality != null)
                {
                    var str = "[houseQuality]=@houseQuality AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseQuality", house.HouseQuality.ID));
                }
                #endregion

                #region 交易类型
                if (house.TransactionType != null)
                {
                    var str = "([transactionType]=@transactionType OR [transactionType]=3) AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@transactionType", house.TransactionType.ID));
                }
                #endregion

                #region 房屋用途
                if (house.HouseUseType != null)
                {
                    var str = "[houseUseType]=@houseUseType AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseUseType", house.HouseUseType.ID));
                }
                #endregion

                #region 房屋类型
                if (house.HouseType != null)
                {
                    var str = "[houseUseType]=@houseUseType AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@houseUseType", house.HouseUseType.ID));
                }
                #endregion

                #region 房屋朝向
                if (house.Orientation != null)
                {
                    var str = "[orientation]=@orientation AND ";
                    search.Append(str);
                    search2.Append(str);
                    sqlParList.Add(new SqlParameter("@orientation", house.Orientation.ID));
                }
                #endregion

                #region 价格
                if (house.SalePriceFrom != 0 || house.SalePriceTo != 0)
                {
                    search.Append("[saleTotalPrice] >=@salePriceFrom");
                    search2.Append("[saleTotalPrice] >=@salePriceFrom");
                    sqlParList.Add(new SqlParameter("@salePriceFrom", house.SalePriceFrom));
                    if (house.SalePriceTo != 0)
                    {
                        search.Append(" AND [saleTotalPrice] <=@salePriceTo");
                        search2.Append(" AND [saleTotalPrice] <=@salePriceTo");
                        sqlParList.Add(new SqlParameter("@salePriceTo", house.SalePriceTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 面积
                if (house.HouseSizeFrom != 0 || house.HouseSizeTo != 0)
                {
                    search.Append("[houseSize] >=@houseSizeFrom");
                    search2.Append("[houseSize] >=@houseSizeFrom");
                    sqlParList.Add(new SqlParameter("@houseSizeFrom", house.HouseSizeFrom));
                    if (house.HouseSizeTo != 0)
                    {
                        search.Append(" AND [houseSize] <=@houseSizeTo");
                        search2.Append(" AND [houseSize] <=@houseSizeTo");
                        sqlParList.Add(new SqlParameter("@houseSizeTo", house.HouseSizeTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 楼层
                if (house.FloorFrom != 0 || house.FloorTo != 0)
                {
                    search.Append("[floor] >=@floorFrom");
                    search2.Append("[floor] >=@floorFrom");
                    sqlParList.Add(new SqlParameter("@floorFrom", house.FloorFrom));
                    if (house.HouseSizeTo != 0)
                    {
                        search.Append(" AND [floor] <=@floorTo");
                        search2.Append(" AND [floor] <=@floorTo");
                        sqlParList.Add(new SqlParameter("@floorTo", house.FloorTo));
                    }
                    search.Append(" AND ");
                    search2.Append(" AND ");
                }
                #endregion

                #region 部门或者员工
                if (house.Department != null || house.Staff != null)
                {
                    search.Append("[department] >=@department");
                    search2.Append("[department] >=@department");
                    sqlParList.Add(new SqlParameter("@department", house.Department.ID));
                    if (house.Staff.ID != 0)
                    {
                        search.Append(" AND [staff] <=@staff");
                        search2.Append(" AND [staff] <=@staff");
                        sqlParList.Add(new SqlParameter("@staff", house.Staff.ID));
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
                sql.Append(string.Format("SELECT * FROM (SELECT TOP {0} Count(*) OVER() AS totalHouseCount, City.CityID, City.ProID AS cityProID, City.CityName, District.ID AS disID, District.DisName, District.CityID AS disCityID, Area.ID AS areaID, areaName, ResidentialDistrict.ID AS rdID, ResidentialDistrict.name AS rdName, address, HousingLetter.ID AS letterID, HousingLetter.letterName, HouseQuality.ID AS qualityID, qualityName, TransactionType.ID AS transactionTypeID, transactionTypeName, Orientation.ID AS orientationID, orientationName, HouseUseType.ID AS useTypeID, HouseUseType.typeName AS useTypeName, HouseType.ID AS houseTypeID, HouseType.typeName AS houseTypeName, HouseStatus.ID AS statusID, HouseStatus.statusName, TaxPayType.ID AS taxPayTypeID, TaxPayType.typeName AS taxPayTypeName, DecorationType.ID AS decorationTypeID, DecorationType.typeName AS decorationTypeName, HouseDocumentType.ID AS houseDocumentTypeID, HouseDocumentType.typeName AS houseDocumentTypeName, HousePayType.ID AS housePayTypeID, HousePayType.typeName AS housePayTypeName, CommissionPayType.ID AS commissionPayTypeID, CommissionPayType.typeName AS commissionPayTypeName, LookHouseType.ID AS lookHouseTypeID, LookHouseType.typeName AS lookHouseTypeName, Source.ID AS sourceID, sourceName, h.ID as hID,[housePosition],[totalFloor],[houseNumber],[roomCount],[hallCount],[toiletCount],[balconyCount],[houseSize],[houseUseSize],[orientation],[saleTotalPrice],[leaseTotalPrice],[proxyStartDate],[proxyOverDate],[lastFollowDate],[houseCreateDate],[originalPrice],[supporting],[ownerName],[ownerPhone],[contacts],[contactPhone],[remarks], h.lastUpdateDate, h.createDate FROM[House] AS h ", houseMaxCount));     
                sql.Append("LEFT JOIN [City] ON h.city=[City].CityID ");
                sql.Append("LEFT JOIN [District] ON h.district=[District].Id ");
                sql.Append("LEFT JOIN [Area] ON h.area=[Area].ID ");
                sql.Append("LEFT JOIN [ResidentialDistrict] ON h.residentialDistrict=[ResidentialDistrict].ID ");
                sql.Append("LEFT JOIN [HousingLetter] ON h.housingLetter=[HousingLetter].ID ");
                sql.Append("LEFT JOIN [Orientation] ON h.orientation=[Orientation].ID ");
                sql.Append("LEFT JOIN [HouseQuality] ON h.houseQuality=[HouseQuality].ID ");
                sql.Append("LEFT JOIN [TransactionType] ON h.transactionType=[TransactionType].ID ");
                sql.Append("LEFT JOIN [HouseUseType] ON h.houseUseType=[HouseUseType].ID ");
                sql.Append("LEFT JOIN [HouseType] ON h.houseType=[HouseType].ID ");
                sql.Append("LEFT JOIN [HouseStatus] ON h.houseStatus=[HouseStatus].ID ");
                sql.Append("LEFT JOIN [TaxPayType] ON h.taxPayType=[TaxPayType].ID ");
                sql.Append("LEFT JOIN [DecorationType] ON h.decorationType=[DecorationType].ID ");
                sql.Append("LEFT JOIN [HouseDocumentType] ON h.houseDocumentType=[HouseDocumentType].ID ");
                sql.Append("LEFT JOIN [HousePayType] ON h.housePayType=[HousePayType].ID ");
                sql.Append("LEFT JOIN [CommissionPayType] ON h.commissionPayType=[CommissionPayType].ID ");
                sql.Append("LEFT JOIN [LookHouseType] ON h.lookHouseType=[LookHouseType].ID ");
                sql.Append("LEFT JOIN [Source] ON h.source=[Source].ID ");
                sql.Append(string.Format("WHERE {0} h.ID NOT IN (SELECT TOP ({1} * ({2}-1)) ID FROM House {3}) ", searchStr, houseMaxCount, house.PageIndex, searchStr2 != "" ? (" WHERE " + (searchStr2.Substring(0, searchStr2.LastIndexOf("AND")))) : ""));
                sql.Append(" ORDER BY h.ID)temp ORDER BY temp.proxyStartDate");
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString(), sqlParList.ToArray());
                while (result.Read())
                {

                    House obj = new House();
                    obj.ID = Convert.ToInt32(result["hID"]);      
                    obj.City = new City
                    {
                        ID = Convert.ToInt32(result["CityID"]),
                        ProID = Convert.ToInt32(result["cityProID"]),
                        Name = result["CityName"] != null ? Convert.ToString(result["CityName"]) : ""
                    };
                    obj.District = new District
                    {
                        ID = Convert.ToInt32(result["disID"]),
                        CityID = Convert.ToInt32(result["disCityID"]),
                        Name = result["DisName"] != null ? Convert.ToString(result["DisName"]) : ""
                    };
                    obj.Area = new Area
                    {
                        ID = Convert.ToInt32(result["areaID"]),
                        AreaName = Convert.ToString(result["areaName"])
                    };
                    obj.ResidentialDistrict = new ResidentialDistrict
                    {
                        ID = result["rdID"] != null ? Convert.ToInt32(result["rdID"]) : 0,
                        Name = result["rdName"] != null ? Convert.ToString(result["rdName"]) : "",
                        Address = result["address"] != null ? Convert.ToString(result["address"]) : ""
                    };
                    obj.HousePosition = result["housePosition"] != null ? Convert.ToString(result["housePosition"]) : "";
                    obj.TotalFloor = Convert.ToString(result["totalFloor"]) != "" ? Convert.ToInt32(result["totalFloor"]) : 0;
                    obj.HouseNumber = result["houseNumber"] != null ? Convert.ToString(result["houseNumber"]) : "";
                    obj.RoomCount = result["roomCount"] != null ? Convert.ToInt32(result["roomCount"]) : 0;
                    obj.HallCount = result["hallCount"] != null ? Convert.ToInt32(result["hallCount"]) : 0;
                    obj.ToiletCount = result["toiletCount"] != null ? Convert.ToInt32(result["toiletCount"]) : 0;
                    obj.BalconyCount = result["balconyCount"] != null ? Convert.ToInt32(result["balconyCount"]) : 0;
                    obj.HouseSize = result["houseSize"] != null ? Convert.ToSingle(result["houseSize"]) : 0;
                    obj.HouseUseSize = Convert.ToString(result["houseUseSize"]) != "" ? Convert.ToSingle(result["houseUseSize"]) : 0;
                    obj.SaleTotalPrice = result["saleTotalPrice"] != null ? Convert.ToDecimal(result["saleTotalPrice"]) : 0;
                    obj.LeaseTotalPrice = result["leaseTotalPrice"] != null ? Convert.ToDecimal(result["leaseTotalPrice"]) : 0;
                    obj.ProxyStartDate = result["proxyStartDate"] != null ? Convert.ToDateTime(result["proxyStartDate"]) : new DateTime();
                    obj.LastFollowDate = result["lastFollowDate"] != null ? Convert.ToDateTime(result["lastFollowDate"]) : new DateTime();
                    obj.HouseCreateDate = result["houseCreateDate"] != null ? Convert.ToString(result["houseCreateDate"]) : "";
                    obj.OriginalPrice = result["originalPrice"] != null ? Convert.ToDecimal(result["originalPrice"]) : 0;
                    obj.Supporting = result["supporting"] != null ? Convert.ToString(result["supporting"]) : "";
                    obj.Orientation = new Orientation
                    {
                        ID = Convert.ToInt32(result["orientationID"]),
                        OrientationName = Convert.ToString(result["orientationName"])
                    };
                    obj.HousingLetter = new HousingLetter
                    {
                        ID = Convert.ToInt32(result["letterID"]),
                        LetterName = Convert.ToString(result["letterName"])
                    };
                    obj.HouseQuality = new HouseQuality
                    {
                        ID = result["qualityID"] != null ? Convert.ToInt32(result["qualityID"]) : 0,
                        QualityName = result["qualityName"] != null ? Convert.ToString(result["qualityName"]) : ""
                    };
                    obj.TransactionType = new TransactionType
                    {
                        ID = result["transactionTypeID"] != null ? Convert.ToInt32(result["transactionTypeID"]) : 0,
                        TransactionTypeName = result["transactionTypeName"] != null ? Convert.ToString(result["transactionTypeName"]) : ""
                    };
                    obj.HouseUseType = new HouseUseType
                    {
                        ID = result["useTypeID"] != null ? Convert.ToInt32(result["useTypeID"]) : 0,
                        TypeName = result["useTypeName"] != null ? Convert.ToString(result["useTypeName"]) : ""
                    };
                    obj.HouseType = new HouseType
                    {
                        ID = result["houseTypeID"] != null ? Convert.ToInt32(result["houseTypeID"]) : 0,
                        TypeName = result["houseTypeName"] != null ? Convert.ToString(result["houseTypeName"]) : ""
                    };
                    obj.HouseStatus = new HouseStatus
                    {
                        ID = result["statusID"] != null ? Convert.ToInt32(result["statusID"]) : 0,
                        StatusName = result["statusName"] != null ? Convert.ToString(result["statusName"]) : ""
                    };
                    obj.TaxPayType = new TaxPayType
                    {
                        ID = result["taxPayTypeID"] != null ? Convert.ToInt32(result["taxPayTypeID"]) : 0,
                        TypeName = result["taxPayTypeName"] != null ? Convert.ToString(result["taxPayTypeName"]) : ""
                    };
                    obj.DecorationType = new DecorationType
                    {
                        ID = result["decorationTypeID"] != null ? Convert.ToInt32(result["decorationTypeID"]) : 0,
                        TypeName = result["decorationTypeName"] != null ? Convert.ToString(result["decorationTypeName"]) : ""
                    };
                    obj.HouseDocumentType = new HouseDocumentType
                    {
                        ID = result["houseDocumentTypeID"] != null ? Convert.ToInt32(result["houseDocumentTypeID"]) : 0,
                        TypeName = result["houseDocumentTypeName"] != null ? Convert.ToString(result["houseDocumentTypeName"]) : ""
                    };
                    obj.HousePayType = new HousePayType
                    {
                        ID = result["housePayTypeID"] != null ? Convert.ToInt32(result["housePayTypeID"]) : 0,
                        TypeName = result["housePayTypeName"] != null ? Convert.ToString(result["housePayTypeName"]) : ""
                    };
                    obj.CommissionPayType = new CommissionPayType
                    {
                        ID = result["commissionPayTypeID"] != null ? Convert.ToInt32(result["commissionPayTypeID"]) : 0,
                        TypeName = result["commissionPayTypeName"] != null ? Convert.ToString(result["commissionPayTypeName"]) : ""
                    };
                    obj.LookHouseType = new LookHouseType
                    {
                        ID = result["lookHouseTypeID"] != null ? Convert.ToInt32(result["lookHouseTypeID"]) : 0,
                        TypeName = result["lookHouseTypeName"] != null ? Convert.ToString(result["lookHouseTypeName"]) : ""
                    };
                    obj.Source = new Source
                    {
                        ID = Convert.ToInt32(result["sourceID"]),
                        SourceName = Convert.ToString(result["sourceName"])
                    };
                    obj.OwnerName = result["ownerName"] != null ? Convert.ToString(result["ownerName"]) : "";
                    obj.OwnerPhone = result["ownerPhone"] != null ? Convert.ToString(result["ownerPhone"]) : "";
                    obj.Contacts = result["contacts"] != null ? Convert.ToString(result["contacts"]) : "";
                    obj.ContactPhone = result["contactPhone"] != null ? Convert.ToString(result["contactPhone"]) : "";
                    obj.Remarks = result["remarks"] != null ? Convert.ToString(result["remarks"]) : "";
                    obj.TotalHouseCount = Convert.ToInt32(result["totalHouseCount"]);
                    obj.PageIndex = house.PageIndex;
                    houseList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return houseList;
        }

        public bool AddHouse(House house)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO House(entrustID, province,city,district,area,residentialDistrict,totalFloor,floor,housePosition,houseNumber,roomCount,hallCount,toiletCount,balconyCount,houseSize,houseUseSize,orientation,saleTotalPrice,minSalePrice,leaseTotalPrice,minLeasePrice,managementPrice,submitHouseDate,proxyStartDate,entrustType,department,staff,lastFollowDate,houseCreateDate,housingLetter,houseQuality,transactionType,houseUseType,houseType,houseStatus,[current],taxPayType,originalPrice,decorationType,houseDocumentType,housePayType,supporting,commissionPayType,LookHouseType,ownerName,ownerPhone,contacts,contactPhone,propertyOwn,furniture,appliance,source,remarks,lastUpdateStaff,lastUpdateDate) VALUES(@entrustID, @province,@city,@district,@area,@residentialDistrict,@totalFloor,@floor,@housePosition,@houseNumber,@roomCount,@hallCount,@toiletCount,@balconyCount,@houseSize,@houseUseSize,@orientation,@saleTotalPrice,@minSalePrice,@leaseTotalPrice,@minLeasePrice,@managementPrice,@submitHouseDate,@proxyStartDate,@entrustType,@department,@staff,@lastFollowDate,@houseCreateDate,@housingLetter,@houseQuality,@transactionType,@houseUseType,@houseType,@houseStatus,@current,@taxPayType,@originalPrice,@decorationType,@houseDocumentType,@housePayType,@supporting,@commissionPayType,@LookHouseType,@ownerName,@ownerPhone,@contacts,@contactPhone,@propertyOwn,@furniture,@appliance,@source,@remarks,@lastUpdateStaff,@lastUpdateDate)";
                var nowDateTime = DateTime.Now;
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@entrustID", house.EntrustID));
                sqlPars.Add(new SqlParameter("@province", house.Province.ID));
                sqlPars.Add(new SqlParameter("@city", house.City.ID));
                sqlPars.Add(new SqlParameter("@district", house.District.ID));
                sqlPars.Add(new SqlParameter("@area", house.Area.ID));
                sqlPars.Add(new SqlParameter("@residentialDistrict", house.ResidentialDistrict.ID));
                sqlPars.Add(new SqlParameter("@totalFloor", house.TotalFloor));
                sqlPars.Add(new SqlParameter("@floor", house.Floor));
                sqlPars.Add(new SqlParameter("@housePosition", house.HousePosition));
                sqlPars.Add(new SqlParameter("@houseNumber", house.HouseNumber));
                sqlPars.Add(new SqlParameter("@roomCount", house.RoomCount));
                sqlPars.Add(new SqlParameter("@hallCount", house.HallCount));
                sqlPars.Add(new SqlParameter("@toiletCount", house.ToiletCount));
                sqlPars.Add(new SqlParameter("@balconyCount", house.BalconyCount));
                sqlPars.Add(new SqlParameter("@houseSize", house.HouseSize));
                sqlPars.Add(new SqlParameter("@houseUseSize", house.HouseUseSize));
                sqlPars.Add(new SqlParameter("@orientation", house.Orientation.ID));
                sqlPars.Add(new SqlParameter("@saleTotalPrice", house.SaleTotalPrice));
                sqlPars.Add(new SqlParameter("@minSalePrice", house.MinSalePrice));
                sqlPars.Add(new SqlParameter("@leaseTotalPrice", house.LeaseTotalPrice));
                sqlPars.Add(new SqlParameter("@minLeasePrice", house.MinLeasePrice));
                sqlPars.Add(new SqlParameter("@managementPrice", house.ManagementPrice));
                sqlPars.Add(new SqlParameter("@submitHouseDate", ""));
                sqlPars.Add(new SqlParameter("@entrustType", house.EntrustType.ID));
                sqlPars.Add(new SqlParameter("@proxyStartDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@department", 1));
                sqlPars.Add(new SqlParameter("@staff", 1));
                sqlPars.Add(new SqlParameter("@lastFollowDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@houseCreateDate", house.HouseCreateDate));
                sqlPars.Add(new SqlParameter("@housingLetter", house.HousingLetter.ID));
                sqlPars.Add(new SqlParameter("@houseQuality", house.HouseQuality.ID));
                sqlPars.Add(new SqlParameter("@transactionType", house.TransactionType.ID));
                sqlPars.Add(new SqlParameter("@houseUseType", house.HouseUseType.ID));
                sqlPars.Add(new SqlParameter("@houseType", house.HouseType.ID));
                sqlPars.Add(new SqlParameter("@houseStatus", house.HouseStatus.ID));
                sqlPars.Add(new SqlParameter("@current", house.Current.ID));
                sqlPars.Add(new SqlParameter("@taxPayType", house.TaxPayType.ID));
                sqlPars.Add(new SqlParameter("@originalPrice", house.OriginalPrice));
                sqlPars.Add(new SqlParameter("@decorationType", house.DecorationType.ID));
                sqlPars.Add(new SqlParameter("@houseDocumentType", house.HouseDocumentType.ID));
                sqlPars.Add(new SqlParameter("@housePayType", house.HousePayType.ID));
                sqlPars.Add(new SqlParameter("@supporting", house.Supporting));
                sqlPars.Add(new SqlParameter("@commissionPayType", house.CommissionPayType.ID));
                sqlPars.Add(new SqlParameter("@lookHouseType", house.LookHouseType.ID));
                sqlPars.Add(new SqlParameter("@ownerName", house.OwnerName));
                sqlPars.Add(new SqlParameter("@ownerPhone", house.OwnerPhone));
                sqlPars.Add(new SqlParameter("@contacts", house.Contacts));
                sqlPars.Add(new SqlParameter("@contactPhone", house.ContactPhone));
                sqlPars.Add(new SqlParameter("@propertyOwn", house.PropertyOwn.ID));
                sqlPars.Add(new SqlParameter("@furniture", house.Furniture.ID));
                sqlPars.Add(new SqlParameter("@appliance", house.Appliance.ID));
                sqlPars.Add(new SqlParameter("@source", house.Source.ID));
                sqlPars.Add(new SqlParameter("@remarks", house.Remarks));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", 1));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
                //var imgSql = "INSERT INTO Image(houseID,fileName,createStaff,createDate,lastUpdateDate,lastUpdateStaff) VALUES(@houseID,@fileName,@createStaff,@createDate,@lastUpdateDate,@lastUpdateStaff)";
                //for (int i = 0; i < images.Count; i++)
                //{
                //    var imgSqlPars = new List<SqlParameter>();
                //    imgSqlPars.Add(new SqlParameter("houseID", 1));
                //    imgSqlPars.Add(new SqlParameter("fileName", images[i].FileName));
                //    imgSqlPars.Add(new SqlParameter("createStaff", house.CreateStaff));
                //    imgSqlPars.Add(new SqlParameter("createDate", nowDateTime));
                //    imgSqlPars.Add(new SqlParameter("lastUpdateDate", nowDateTime));
                //    imgSqlPars.Add(new SqlParameter("lastUpdateStaff", house.CreateStaff));
                //    SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, imgSql, imgSqlPars.ToArray());
                //}          
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return result;
        }

        public bool UpdateHouse(House house)
        {
            var result = false;
            try
            {
                var sql = "UPDATE House SET entrustID=@entrustID, province=@province,city=@city,district=@district,area=@area,residentialDistrict=@residentialDistrict,totalFloor=@totalFloor,floor=@floor,housePosition=@housePosition,houseNumber=@houseNumber,roomCount=@roomCount,hallCount=@hallCount,toiletCount=@toiletCount,balconyCount=@balconyCount,houseSize=@houseSize,houseUseSize=@houseUseSize,orientation=@orientation,saleTotalPrice=@saleTotalPrice,minSalePrice=@minSalePrice,leaseTotalPrice=@leaseTotalPrice,minLeasePrice=@minLeasePrice,managementPrice=@managementPrice,submitHouseDate=@submitHouseDate,entrustType=@entrustType,department=@department,staff=@staff,houseCreateDate=@houseCreateDate,housingLetter=@housingLetter,houseQuality=@houseQuality,transactionType=@transactionType,houseUseType=@houseUseType,houseType=@houseType,houseStatus=@houseStatus,[current]=@current,taxPayType=@taxPayType,originalPrice=@originalPrice,decorationType=@decorationType,houseDocumentType=@houseDocumentType,housePayType=@housePayType,supporting=@supporting,commissionPayType=@commissionPayType,LookHouseType=@LookHouseType,ownerName=@ownerName,ownerPhone=@ownerPhone,contacts=@contacts,contactPhone=@contactPhone,propertyOwn=@propertyOwn,furniture=@furniture,appliance=@appliance,source=@source,remarks=@remarks,lastUpdateStaff=@lastUpdateStaff,lastUpdateDate=@lastUpdateDate WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", house.ID));
                sqlPars.Add(new SqlParameter("@entrustID", house.EntrustID));
                sqlPars.Add(new SqlParameter("@province", house.Province.ID));
                sqlPars.Add(new SqlParameter("@city", house.City.ID));
                sqlPars.Add(new SqlParameter("@district", house.District.ID));
                sqlPars.Add(new SqlParameter("@area", house.Area.ID));
                sqlPars.Add(new SqlParameter("@residentialDistrict", house.ResidentialDistrict.ID));
                sqlPars.Add(new SqlParameter("@totalFloor", house.TotalFloor));
                sqlPars.Add(new SqlParameter("@floor", house.Floor));
                sqlPars.Add(new SqlParameter("@housePosition", house.HousePosition));
                sqlPars.Add(new SqlParameter("@houseNumber", house.HouseNumber));
                sqlPars.Add(new SqlParameter("@roomCount", house.RoomCount));
                sqlPars.Add(new SqlParameter("@hallCount", house.HallCount));
                sqlPars.Add(new SqlParameter("@toiletCount", house.ToiletCount));
                sqlPars.Add(new SqlParameter("@balconyCount", house.BalconyCount));
                sqlPars.Add(new SqlParameter("@houseSize", house.HouseSize));
                sqlPars.Add(new SqlParameter("@houseUseSize", house.HouseUseSize));
                sqlPars.Add(new SqlParameter("@orientation", house.Orientation.ID));
                sqlPars.Add(new SqlParameter("@saleTotalPrice", house.SaleTotalPrice));
                sqlPars.Add(new SqlParameter("@minSalePrice", house.MinSalePrice));
                sqlPars.Add(new SqlParameter("@leaseTotalPrice", house.LeaseTotalPrice));
                sqlPars.Add(new SqlParameter("@minLeasePrice", house.MinLeasePrice));
                sqlPars.Add(new SqlParameter("@managementPrice", house.ManagementPrice));
                sqlPars.Add(new SqlParameter("@submitHouseDate", ""));
                sqlPars.Add(new SqlParameter("@entrustType", house.EntrustType.ID));
                sqlPars.Add(new SqlParameter("@department", 1));
                sqlPars.Add(new SqlParameter("@staff", 1));
                sqlPars.Add(new SqlParameter("@houseCreateDate", house.HouseCreateDate));
                sqlPars.Add(new SqlParameter("@housingLetter", house.HousingLetter.ID));
                sqlPars.Add(new SqlParameter("@houseQuality", house.HouseQuality.ID));
                sqlPars.Add(new SqlParameter("@transactionType", house.TransactionType.ID));
                sqlPars.Add(new SqlParameter("@houseUseType", house.HouseUseType.ID));
                sqlPars.Add(new SqlParameter("@houseType", house.HouseType.ID));
                sqlPars.Add(new SqlParameter("@houseStatus", house.HouseStatus.ID));
                sqlPars.Add(new SqlParameter("@current", house.Current.ID));
                sqlPars.Add(new SqlParameter("@taxPayType", house.TaxPayType.ID));
                sqlPars.Add(new SqlParameter("@originalPrice", house.OriginalPrice));
                sqlPars.Add(new SqlParameter("@decorationType", house.DecorationType.ID));
                sqlPars.Add(new SqlParameter("@houseDocumentType", house.HouseDocumentType.ID));
                sqlPars.Add(new SqlParameter("@housePayType", house.HousePayType.ID));
                sqlPars.Add(new SqlParameter("@supporting", house.Supporting));
                sqlPars.Add(new SqlParameter("@commissionPayType", house.CommissionPayType.ID));
                sqlPars.Add(new SqlParameter("@lookHouseType", house.LookHouseType.ID));
                sqlPars.Add(new SqlParameter("@ownerName", house.OwnerName));
                sqlPars.Add(new SqlParameter("@ownerPhone", house.OwnerPhone));
                sqlPars.Add(new SqlParameter("@contacts", house.Contacts));
                sqlPars.Add(new SqlParameter("@contactPhone", house.ContactPhone));
                sqlPars.Add(new SqlParameter("@propertyOwn", house.PropertyOwn.ID));
                sqlPars.Add(new SqlParameter("@furniture", house.Furniture.ID));
                sqlPars.Add(new SqlParameter("@appliance", house.Appliance.ID));
                sqlPars.Add(new SqlParameter("@source", house.Source.ID));
                sqlPars.Add(new SqlParameter("@remarks", house.Remarks));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", 1));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteHouse(List<int> idArr)
        {
            var result = false;
            try
            {
                var sql = "DELETE FROM House WHERE ID=@ID";
                for (int i = 0; i < idArr.Count(); i++)
                {
                    var sqlPars = new List<SqlParameter>();
                    sqlPars.Add(new SqlParameter("@ID", idArr[i]));
                    result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
                }


            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
