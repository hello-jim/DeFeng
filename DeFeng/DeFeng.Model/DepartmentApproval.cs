using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class DepartmentApproval
    {
        private int id;
        private Staff approvalStaff;//审批员工
        private Department department;//审批部门
        private ApprovalType approvalType;//审批类型
        private int approvaLevel;//审批等级
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

        public Staff ApprovalStaff
        {
            get
            {
                return approvalStaff;
            }

            set
            {
                approvalStaff = value;
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

        public ApprovalType ApprovalType
        {
            get
            {
                return approvalType;
            }

            set
            {
                approvalType = value;
            }
        }

        public int ApprovaLevel
        {
            get
            {
                return approvaLevel;
            }

            set
            {
                approvaLevel = value;
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

    public enum ApprovalType
    {
        EntryApply = 1
    }
}
