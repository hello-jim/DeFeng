using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class ResidentialDistrict
    {
        private int id;
        private string name;
        private string city;//城市
        private string area;//城区
        private string propertyUsage;//用途
        private string propertyType;//类型
        private string address;//地址
        private DateTime residentialDistrictCreateDate;//楼盘建成日期
        private string mgtCompany;//物业公司
        private string mgtTel;//物业电话
        private string mgtPrice;//管业管理费
        private decimal avgSalePrice;//平均销售价格
        private string environment;//周边环境
        private string transportation;//交通设施
        private string education;//学校教育
        private string business;//商业贸易
        private string entertainment;//休闲娱乐
        private bool buildingRule;//栋楼规则
        private int roomRule;//房号规则
        private string roomRuleEx;//房号例外规则
        private string remark;//备注
        private DateTime createDate;//创建日期
        private string createStaff;//创建人
        private DateTime lastUpdateDate;//最后修改时间
        private string lastUpdateStaff;//最后修改人

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string City
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

        public string Area
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

        public string PropertyUsage
        {
            get
            {
                return propertyUsage;
            }

            set
            {
                propertyUsage = value;
            }
        }

        public string PropertyType
        {
            get
            {
                return propertyType;
            }

            set
            {
                propertyType = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public DateTime ResidentialDistrictCreateDate
        {
            get
            {
                return residentialDistrictCreateDate;
            }

            set
            {
                residentialDistrictCreateDate = value;
            }
        }

        public string MgtCompany
        {
            get
            {
                return mgtCompany;
            }

            set
            {
                mgtCompany = value;
            }
        }

        public string MgtTel
        {
            get
            {
                return mgtTel;
            }

            set
            {
                mgtTel = value;
            }
        }

        public string MgtPrice
        {
            get
            {
                return mgtPrice;
            }

            set
            {
                mgtPrice = value;
            }
        }

        public decimal AvgSalePrice
        {
            get
            {
                return avgSalePrice;
            }

            set
            {
                avgSalePrice = value;
            }
        }

        public string Environment
        {
            get
            {
                return environment;
            }

            set
            {
                environment = value;
            }
        }

        public string Transportation
        {
            get
            {
                return transportation;
            }

            set
            {
                transportation = value;
            }
        }

        public string Education
        {
            get
            {
                return education;
            }

            set
            {
                education = value;
            }
        }

        public string Business
        {
            get
            {
                return business;
            }

            set
            {
                business = value;
            }
        }

        public string Entertainment
        {
            get
            {
                return entertainment;
            }

            set
            {
                entertainment = value;
            }
        }

        public bool BuildingRule
        {
            get
            {
                return buildingRule;
            }

            set
            {
                buildingRule = value;
            }
        }

        public int RoomRule
        {
            get
            {
                return roomRule;
            }

            set
            {
                roomRule = value;
            }
        }

        public string RoomRuleEx
        {
            get
            {
                return roomRuleEx;
            }

            set
            {
                roomRuleEx = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
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

        public string CreateStaff
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

        public string LastUpdateStaff
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

    }
}
