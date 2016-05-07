using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class CustomerFollowRecord
    {
        private int id;
        private int customerID;
        private FollowType followType;
        private string followContent;
        private Staff createStaff;
        private DateTime createDate;
        private Staff lastUpdateStaff;
        private DateTime lastUpdateDate;

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

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public FollowType FollowType
        {
            get
            {
                return followType;
            }

            set
            {
                followType = value;
            }
        }

        public string FollowContent
        {
            get
            {
                return followContent;
            }

            set
            {
                followContent = value;
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
    }
}
