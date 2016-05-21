using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Department
    {
        private int id;
        private string departmentName;//组名
        private int parent;//上级部门
        private int level;//层次
        private DateTime lastUpdateDate;//最后修改时间
        private Staff lastUpdateStaff;//最后修改人
        private DateTime createDate;//创建时间
        private Staff createStaff;
        private int sortNo;//排序ID

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

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }

            set
            {
                departmentName = value;
            }
        }

        public int Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
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

        public int SortNo
        {
            get
            {
                return sortNo;
            }

            set
            {
                sortNo = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
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
    }
}
