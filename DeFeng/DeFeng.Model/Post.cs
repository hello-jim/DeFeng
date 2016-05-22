using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Post
    {
        private int id;
        private string postName;//岗位名
        private Department department;
        private string description;//描述
        private bool isEnable;
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

        public string PostName
        {
            get
            {
                return postName;
            }

            set
            {
                postName = value;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public bool IsEnable
        {
            get
            {
                return isEnable;
            }

            set
            {
                isEnable = value;
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
