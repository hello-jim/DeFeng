using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class SecondHandHouseEarnest
    {
        private int id;
        private string shop;//门店
        private string project;//项目
        private string houseBuilding;//房栋
        private string unit;//单元
        private string houseNo;//房号
        private string customerName;//客户姓名(买房)
        private decimal earnest;//定金
        private DateTime payEarnestDate;//交定日期
        private string mark;//送审标识
        private string attachmentName;//附件
        private Staff createStaff;
        private DateTime createDate;
        private DateTime lastUpdateDate;
        private Staff lastUpdateStaff;

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

        public string Shop
        {
            get
            {
                return shop;
            }

            set
            {
                shop = value;
            }
        }

        public string Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
            }
        }

        public string HouseBuilding
        {
            get
            {
                return houseBuilding;
            }

            set
            {
                houseBuilding = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public string HouseNo
        {
            get
            {
                return houseNo;
            }

            set
            {
                houseNo = value;
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

        public decimal Earnest
        {
            get
            {
                return earnest;
            }

            set
            {
                earnest = value;
            }
        }

        public DateTime PayEarnestDate
        {
            get
            {
                return payEarnestDate;
            }

            set
            {
                payEarnestDate = value;
            }
        }

        public string Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }

        public string AttachmentName
        {
            get
            {
                return attachmentName;
            }

            set
            {
                attachmentName = value;
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
    }
}
