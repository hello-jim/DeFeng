using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class SecondHandHouseTransferEarnest
    {
        private int id;
        private string project;//项目
        private string houseBuilding;//房栋
        private string unit;//单元
        private string houseNo;//房号
        private decimal receivedEarnest;//已收定金
        private decimal sellerCommission;//卖方佣金
        private decimal securityDeposit;//交房保证金
        private decimal transferEarnest;//转定金额
        private TransferEarnestType transferEarnestType;//转定类型
        private string accountName;//开户人
        private string bank;//开户银行
        private string seller;//卖方
        private string shop;//门店
        private string account;//账号
        private string mark;//送审标识
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

        public decimal ReceivedEarnest
        {
            get
            {
                return receivedEarnest;
            }

            set
            {
                receivedEarnest = value;
            }
        }

        public decimal SellerCommission
        {
            get
            {
                return sellerCommission;
            }

            set
            {
                sellerCommission = value;
            }
        }

        public decimal SecurityDeposit
        {
            get
            {
                return securityDeposit;
            }

            set
            {
                securityDeposit = value;
            }
        }

        public decimal TransferEarnest
        {
            get
            {
                return transferEarnest;
            }

            set
            {
                transferEarnest = value;
            }
        }

        public TransferEarnestType TransferEarnestType
        {
            get
            {
                return transferEarnestType;
            }

            set
            {
                transferEarnestType = value;
            }
        }

        public string AccountName
        {
            get
            {
                return accountName;
            }

            set
            {
                accountName = value;
            }
        }

        public string Bank
        {
            get
            {
                return bank;
            }

            set
            {
                bank = value;
            }
        }

        public string Seller
        {
            get
            {
                return seller;
            }

            set
            {
                seller = value;
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

        public string Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
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
