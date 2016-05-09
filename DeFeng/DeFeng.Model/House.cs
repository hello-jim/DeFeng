using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class House
    {
        private int id;//房源ID
        private string entrustID;//委托编号
        private Province province;//省
        private City city;//城
        private District district;//城区
        private Area area;//区域
        private ResidentialDistrict residentialDistrict;//住宅小区
        private int residential_district_Type;//住宅小区类型
        private string housePosition;//房屋位置
        private int totalFloor;//总层
        private int floor;//楼层
        private int floorFrom;
        private int floorTo;
        private string houseNumber;//房号
        private int roomCount;//房间数量
        private int hallCount;//厅数量
        private int toiletCount;//卫生间数量
        private int balconyCount;//阳台数量
        private float houseSize;//房屋面积
        private float houseUseSize;//房屋实用面积
        private float houseSizeFrom;//房屋面积从多少
        private float houseSizeTo;//房屋面积至多少
        private Orientation orientation;//朝向
        private decimal saleTotalPrice;//销售总价
        private decimal minSalePrice;//销售底价
        private decimal leaseTotalPrice;//出租总价
        private decimal minLeasePrice;//出租底价
        private decimal managementPrice;//管理费
        private DateTime submitHouseDate;//交房日期
        private decimal salePriceFrom;//销售价格从多少....
        private decimal salePriceTo;//销售价格至多少....
        private DateTime proxyStartDate;//代理开始时间   
        private DateTime proxyOverDate;//代理结束时间
        private EntrustType entrustType;//委托方式
        private Department department;//所属部门
        private Staff staff;//员工ID
        private DateTime lastFollowDate;//最后跟进日期
        private string houseCreateDate="";//房屋创建日期
        //private DateTime leaseDate;//出租日期
        //private DateTime saleDate;//销售日期
        private HousingLetter housingLetter; //盘符(如公盘、私盘、封盘等)
        private HouseQuality houseQuality;//房屋品质(例如优质房，聚焦房等)
        private TransactionType transactionType;//交易类型(如出售、出租等)
        private HouseUseType houseUseType;//房屋使用类型(如商铺、住宅、写字楼)
        private HouseType houseType;//房屋类型(如多层、单层等)
        private HouseStatus houseStatus;//房屋状态
        private Current current;//现状(如空房,业主住，租客住等)
        private TaxPayType taxPayType;//税费支付方式
        private decimal originalPrice;//房屋原购价
        private DecorationType decorationType;//装修类型
        private HouseDocumentType houseDocumentType;//证件(如购房合同、房地产证)
        private HousePayType housePayType;//出售支付方式
        private string supporting;//配套(如地砖、木地板)
        private CommissionPayType commissionPayType;//佣金支付方式
        private LookHouseType lookHouseType;//看房方式
        private string ownerName="";//业主名称
        private string ownerPhone="";//业主电话
        private string contacts="";//联系人
        private string contactPhone="";//联系人电话
        private PropertyOwn propertyOwn;//产权
        private Furniture furniture;//家具
        private Appliance appliance;//家电
        private Source source;//房源来源
        private string remarks="";//备注
        private Staff lastUpdateStaff;//最后修改员工
        private DateTime lastUpdateDate;//最后修改时间
        private DateTime createDate;//创建时间
        private Staff createStaff;//创建员工
        private int pageIndex = 1;
        private int totalHouseCount;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public District District
        {
            get
            {
                return district;
            }

            set
            {
                district = value;
            }
        }

        public Area Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public ResidentialDistrict ResidentialDistrict
        {
            get
            {
                return residentialDistrict;
            }

            set
            {
                residentialDistrict = value;
            }
        }

        public int Residential_district_Type
        {
            get
            {
                return residential_district_Type;
            }

            set
            {
                residential_district_Type = value;
            }
        }

        public string HousePosition
        {
            get
            {
                return housePosition;
            }

            set
            {
                housePosition = value;
            }
        }

        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }

            set
            {
                houseNumber = value;
            }
        }

        public int RoomCount
        {
            get
            {
                return roomCount;
            }

            set
            {
                roomCount = value;
            }
        }

        public int HallCount
        {
            get
            {
                return hallCount;
            }

            set
            {
                hallCount = value;
            }
        }

        public int ToiletCount
        {
            get
            {
                return toiletCount;
            }

            set
            {
                toiletCount = value;
            }
        }

        public float HouseSize
        {
            get
            {
                return houseSize;
            }

            set
            {
                houseSize = value;
            }
        }

        public float HouseSizeFrom
        {
            get
            {
                return houseSizeFrom;
            }

            set
            {
                houseSizeFrom = value;
            }
        }

        public float HouseSizeTo
        {
            get
            {
                return houseSizeTo;
            }

            set
            {
                houseSizeTo = value;
            }
        }

        public Orientation Orientation
        {
            get
            {
                return orientation;
            }

            set
            {
                orientation = value;
            }
        }

        public decimal SaleTotalPrice
        {
            get
            {
                return saleTotalPrice;
            }

            set
            {
                saleTotalPrice = value;
            }
        }

        public decimal LeaseTotalPrice
        {
            get
            {
                return leaseTotalPrice;
            }

            set
            {
                leaseTotalPrice = value;
            }
        }
        public decimal SalePriceFrom
        {
            get
            {
                return salePriceFrom;
            }

            set
            {
                salePriceFrom = value;
            }
        }

        public decimal SalePriceTo
        {
            get
            {
                return salePriceTo;
            }

            set
            {
                salePriceTo = value;
            }
        }
        public DateTime ProxyStartDate
        {
            get
            {
                return proxyStartDate;
            }

            set
            {
                proxyStartDate = value;
            }
        }

        public DateTime ProxyOverDate
        {
            get
            {
                return proxyOverDate;
            }

            set
            {
                proxyOverDate = value;
            }
        }

        public Department Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public Staff Staff
        {
            get
            {
                return staff;
            }

            set
            {
                staff = value;
            }
        }

        public DateTime LastFollowDate
        {
            get
            {
                return lastFollowDate;
            }

            set
            {
                lastFollowDate = value;
            }
        }

        public string HouseCreateDate
        {
            get
            {
                return houseCreateDate;
            }

            set
            {
                houseCreateDate = value;
            }
        }

        //public DateTime LeaseDate
        //{
        //    get
        //    {
        //        return leaseDate;
        //    }

        //    set
        //    {
        //        leaseDate = value;
        //    }
        //}

        //public DateTime SaleDate
        //{
        //    get
        //    {
        //        return saleDate;
        //    }

        //    set
        //    {
        //        saleDate = value;
        //    }
        //}

        public HousingLetter HousingLetter
        {
            get
            {
                return housingLetter;
            }

            set
            {
                housingLetter = value;
            }
        }

        public HouseQuality HouseQuality
        {
            get
            {
                return houseQuality;
            }

            set
            {
                houseQuality = value;
            }
        }

        public TransactionType TransactionType
        {
            get
            {
                return transactionType;
            }

            set
            {
                transactionType = value;
            }
        }

        public HouseUseType HouseUseType
        {
            get
            {
                return houseUseType;
            }

            set
            {
                houseUseType = value;
            }
        }

        public HouseType HouseType
        {
            get
            {
                return houseType;
            }

            set
            {
                houseType = value;
            }
        }

        public HouseStatus HouseStatus
        {
            get
            {
                return houseStatus;
            }

            set
            {
                houseStatus = value;
            }
        }

        public TaxPayType TaxPayType
        {
            get
            {
                return taxPayType;
            }

            set
            {
                taxPayType = value;
            }
        }

        public decimal OriginalPrice
        {
            get
            {
                return originalPrice;
            }

            set
            {
                originalPrice = value;
            }
        }

        //public PropertyType PropertyType
        //{
        //    get
        //    {
        //        return propertyType;
        //    }

        //    set
        //    {
        //        propertyType = value;
        //    }
        //}

        public DecorationType DecorationType
        {
            get
            {
                return decorationType;
            }

            set
            {
                decorationType = value;
            }
        }

        public HouseDocumentType HouseDocumentType
        {
            get
            {
                return houseDocumentType;
            }

            set
            {
                houseDocumentType = value;
            }
        }

        public HousePayType HousePayType
        {
            get
            {
                return housePayType;
            }

            set
            {
                housePayType = value;
            }
        }

        public string Supporting
        {
            get
            {
                return supporting;
            }

            set
            {
                supporting = value;
            }
        }

        public CommissionPayType CommissionPayType
        {
            get
            {
                return commissionPayType;
            }

            set
            {
                commissionPayType = value;
            }
        }
        public string OwnerName
        {
            get
            {
                return ownerName;
            }

            set
            {
                ownerName = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return ownerPhone;
            }

            set
            {
                ownerPhone = value;
            }
        }

        public string Contacts
        {
            get
            {
                return contacts;
            }

            set
            {
                contacts = value;
            }
        }

        public string ContactPhone
        {
            get
            {
                return contactPhone;
            }

            set
            {
                contactPhone = value;
            }
        }


        public LookHouseType LookHouseType
        {
            get
            {
                return lookHouseType;
            }

            set
            {
                lookHouseType = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }

        public Staff LastUpdateStaff
        {
            get
            {
                return lastUpdateStaff;
            }

            set
            {
                lastUpdateStaff = value;
            }
        }

        public DateTime LastUpdateDate
        {
            get
            {
                return lastUpdateDate;
            }

            set
            {
                lastUpdateDate = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }

            set
            {
                createDate = value;
            }
        }

        public Staff CreateStaff
        {
            get
            {
                return createStaff;
            }

            set
            {
                createStaff = value;
            }
        }

        public City City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public Province Province
        {
            get
            {
                return province;
            }

            set
            {
                province = value;
            }
        }

        public int BalconyCount
        {
            get
            {
                return balconyCount;
            }

            set
            {
                balconyCount = value;
            }
        }

        public int TotalFloor
        {
            get
            {
                return totalFloor;
            }

            set
            {
                totalFloor = value;
            }
        }

        public float HouseUseSize
        {
            get
            {
                return houseUseSize;
            }

            set
            {
                houseUseSize = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }

        public int TotalHouseCount
        {
            get
            {
                return totalHouseCount;
            }

            set
            {
                totalHouseCount = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                floor = value;
            }
        }

        public decimal MinSalePrice
        {
            get
            {
                return minSalePrice;
            }

            set
            {
                minSalePrice = value;
            }
        }

        public decimal MinLeasePrice
        {
            get
            {
                return minLeasePrice;
            }

            set
            {
                minLeasePrice = value;
            }
        }

        public EntrustType EntrustType
        {
            get
            {
                return entrustType;
            }

            set
            {
                entrustType = value;
            }
        }

        public decimal ManagementPrice
        {
            get
            {
                return managementPrice;
            }

            set
            {
                managementPrice = value;
            }
        }

        public string EntrustID
        {
            get
            {
                return entrustID;
            }

            set
            {
                entrustID = value;
            }
        }

        public Source Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public PropertyOwn PropertyOwn
        {
            get
            {
                return propertyOwn;
            }

            set
            {
                propertyOwn = value;
            }
        }

        public DateTime SubmitHouseDate
        {
            get
            {
                return submitHouseDate;
            }

            set
            {
                submitHouseDate = value;
            }
        }

        public Current Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

        public Furniture Furniture
        {
            get
            {
                return furniture;
            }

            set
            {
                furniture = value;
            }
        }

        public Appliance Appliance
        {
            get
            {
                return appliance;
            }

            set
            {
                appliance = value;
            }
        }

        public int FloorFrom
        {
            get
            {
                return floorFrom;
            }

            set
            {
                floorFrom = value;
            }
        }

        public int FloorTo
        {
            get
            {
                return floorTo;
            }

            set
            {
                floorTo = value;
            }
        }
    }
}

