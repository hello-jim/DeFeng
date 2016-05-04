using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Customer
    {
        private int id;//客户编号
        private string customerName;//客户名称
        private string customerPhone;//客户电话
        private string contacts;//联系人
        private string contactsPhone;//联系人电话
        private string idCard;//身份证
        private string presentAddress;//现在住址
        private CustomerDemand customerDemand;//客户需求
        private CustomerStatus customerStatus;//  private CustomerStatus customerStatus;//客户状态(例如已租、已购)
        private CustomerTransactionType customerTransactionType;//交易类型(如求购、求租)
        private bool isPrivateCustomer;//是否是私客
        private bool isQualityCustomer;//是否是优质客
        private bool isPubliceCustomer;//是否是公客
        private City city;//城市
        private District district;//城区
        private Area area;//片区
        private ResidentialDistrict residentialDistrict;//楼盘
        private string position;//位置
        private HouseUseType houseUseType;//房屋使用类型
        private HouseType houseType;//房屋类型
        private int roomCount;//房间数量
        private int hallCount;//厅数量
        private int toiletCount;//卫生间数量
        private int balconyCount;//阳台数量
        private float houseSizeFrom;//房屋面积(从多少....) 
        private float houseSizeTo;//房屋面积(....至多少)
        private float houseSize;//面积
        private decimal price;//价格
        private decimal priceFrom;//价格从...
        private decimal priceTo;//价格至...
        private DateTime entrustStartDate;//委托开始时间
        private Source source;//客户来源
        private Grade grade;//等级
        private Orientation orientation;//房屋朝向
        private Country nationality;//客户国籍
        private string entrustOverDate;//期限
        private int floor;//楼层
        private int floorFrom;
        private int floorTo;
        private int totalFloor;//总层
        private Intention intention;//客户意向
        private DecorationType decorationType;//装修
        private HousePayType housePayType;//支付类型(例如一次性支付)
        private string supporting;//配套设施
        private CommissionPayType commissionPayType;//佣金支付类型
        private EntrustType entrustType;//委托类型
        private CustomerType customerType;//客户类型
        private string remarks;//备注
        private Department department;//部门
        private Staff lastUpdateStaff;//最后修改人
        private DateTime lastUpdateDate;//最后修改时间
        private DateTime createDate;//客户创建日期
        private Staff createStaff;//创建员工      
        private DateTime lastFollowDate;//最后跟进日期
        private ShopArea shopArea;//商铺区域(如热闹，冷清等)
        private ShopLocation shopLocation;//商铺位置
        private string industry;//行业
        private Wall wall;//围墙
        private string electricity;//电量
        private string park;//停车
        private LandType landType;//地皮类型
        private int workerCount;//工人数量
        private int dormCount;//宿舍数量
        private int officeCount;//办公室数量
        private int clearingCount;//空地数量
        private OfficeLevel officeLevel;//办公楼级别
        private CarPark carPark;//停车位
        private LandPlan landPlan;//规划
        private Current current;//现状
        private int pageIndex = 1;
        private int totalCustomerCount;

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

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string CustomerPhone
        {
            get
            {
                return customerPhone;
            }

            set
            {
                customerPhone = value;
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

        public string ContactsPhone
        {
            get
            {
                return contactsPhone;
            }

            set
            {
                contactsPhone = value;
            }
        }

        public string IdCard
        {
            get
            {
                return idCard;
            }

            set
            {
                idCard = value;
            }
        }

        public string PresentAddress
        {
            get
            {
                return presentAddress;
            }

            set
            {
                presentAddress = value;
            }
        }

        public CustomerDemand CustomerDemand
        {
            get
            {
                return customerDemand;
            }

            set
            {
                customerDemand = value;
            }
        }

        public CustomerStatus CustomerStatus
        {
            get
            {
                return customerStatus;
            }

            set
            {
                customerStatus = value;
            }
        }


        public CustomerTransactionType CustomerTransactionType
        {
            get
            {
                return customerTransactionType;
            }

            set
            {
                customerTransactionType = value;
            }
        }

        public bool IsPrivateCustomer
        {
            get
            {
                return isPrivateCustomer;
            }

            set
            {
                isPrivateCustomer = value;
            }
        }

        public bool IsQualityCustomer
        {
            get
            {
                return isQualityCustomer;
            }

            set
            {
                isQualityCustomer = value;
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

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public decimal PriceFrom
        {
            get
            {
                return priceFrom;
            }

            set
            {
                priceFrom = value;
            }
        }

        public decimal PriceTo
        {
            get
            {
                return priceTo;
            }

            set
            {
                priceTo = value;
            }
        }

        public DateTime EntrustStartDate
        {
            get
            {
                return entrustStartDate;
            }

            set
            {
                entrustStartDate = value;
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

        public Grade Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
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

        public Country Nationality
        {
            get
            {
                return nationality;
            }

            set
            {
                nationality = value;
            }
        }

        public string EntrustOverDate
        {
            get
            {
                return entrustOverDate;
            }

            set
            {
                entrustOverDate = value;
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

        public Intention Intention
        {
            get
            {
                return intention;
            }

            set
            {
                intention = value;
            }
        }

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

        public bool IsPubliceCustomer
        {
            get
            {
                return isPubliceCustomer;
            }

            set
            {
                isPubliceCustomer = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
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

        public CustomerType CustomerType
        {
            get
            {
                return customerType;
            }

            set
            {
                customerType = value;
            }
        }

        public int TotalCustomerCount
        {
            get
            {
                return totalCustomerCount;
            }

            set
            {
                totalCustomerCount = value;
            }
        }

        public ShopLocation ShopLocation
        {
            get
            {
                return shopLocation;
            }

            set
            {
                shopLocation = value;
            }
        }

        public string Industry
        {
            get
            {
                return industry;
            }

            set
            {
                industry = value;
            }
        }

        public string Electricity
        {
            get
            {
                return electricity;
            }

            set
            {
                electricity = value;
            }
        }

        public string Park
        {
            get
            {
                return park;
            }

            set
            {
                park = value;
            }
        }

        public Wall Wall
        {
            get
            {
                return wall;
            }

            set
            {
                wall = value;
            }
        }

        public LandType LandType
        {
            get
            {
                return landType;
            }

            set
            {
                landType = value;
            }
        }

        public int WorkerCount
        {
            get
            {
                return workerCount;
            }

            set
            {
                workerCount = value;
            }
        }

        public int DormCount
        {
            get
            {
                return dormCount;
            }

            set
            {
                dormCount = value;
            }
        }

        public int OfficeCount
        {
            get
            {
                return officeCount;
            }

            set
            {
                officeCount = value;
            }
        }

        public int ClearingCount
        {
            get
            {
                return clearingCount;
            }

            set
            {
                clearingCount = value;
            }
        }

        public OfficeLevel OfficeLevel
        {
            get
            {
                return officeLevel;
            }

            set
            {
                officeLevel = value;
            }
        }

        public CarPark CarPark
        {
            get
            {
                return carPark;
            }

            set
            {
                carPark = value;
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

        public LandPlan LandPlan
        {
            get
            {
                return landPlan;
            }

            set
            {
                landPlan = value;
            }
        }

        public ShopArea ShopArea
        {
            get
            {
                return shopArea;
            }

            set
            {
                shopArea = value;
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
    }
}
