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
        private string customerDemand;//客户需求
        private string customerStatus;//客户状态(例如已租、已购)
        private TransactionType transactionType;//交易类型(如求购、求租)
        private int isPrivateCustomer;//是否是私客
        private int isQualityCustomer;//是否是优质客
        private District district;//城区
        private Area area;//片区
        private ResidentialDistrict residentialDistrict;//楼盘地址
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
        private DateTime proxyEndDate;//代理结束时间
        private string source;//客户来源
        private string grade;//等级
        private Orientation orientation;//房屋朝向
        private string nationality;//客户国籍
        private string entrustOverDate;//期限
        private int floor;//楼层
        private int floorFrom;
        private int floorTo;
        private Intention intention;//客户意向
        private DecorationType decorationType;//装修
        private HousePayType housePayType;//支付类型(例如一次性支付)
        private string supporting;//配套设施
        private CommissionPayType commissionPayType;//佣金支付类型
        private string remarks;//备注
        private Department department;//部门
        private Staff lastUpdateStaff;//最后修改人
        private DateTime lastUpdateDate;//最后修改时间
        private DateTime createDate;//客户创建日期
        private Staff createStaff;//创建员工      
        private int pageIndex;

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

        public string CustomerDemand
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

        public string CustomerStatus
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

        public int IsPrivateCustomer
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

        public int IsQualityCustomer
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

        public DateTime ProxyEndDate
        {
            get
            {
                return proxyEndDate;
            }

            set
            {
                proxyEndDate = value;
            }
        }

        public string Source
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

        public string Grade
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

        public string Nationality
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
    }
}
