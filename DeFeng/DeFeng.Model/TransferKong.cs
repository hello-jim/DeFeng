using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class TransferKong
    {
        private int id;
        private Staff staff;//员工
        private int sex;//性别
        private Department department;//部门
        private DateTime applyDate;//申请日期
        private string attachmentName;//附近
        private string transferReason;//调动原因
        private Department originalDepartmentComments;//原部门
        private string networkDepartmentComments;//网络部意见
        private string newDepartmentComments;//新部门意见
        private string personnelDepartmentComments;//人事部意见
        private string viceGeneralManager;//副总经理意见
        private string processImg;//流程图
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

        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
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

        public DateTime ApplyDate
        {
            get
            {
                return applyDate;
            }

            set
            {
                applyDate = value;
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

        public string TransferReason
        {
            get
            {
                return transferReason;
            }

            set
            {
                transferReason = value;
            }
        }

        public Department OriginalDepartmentComments
        {
            get
            {
                return originalDepartmentComments;
            }

            set
            {
                originalDepartmentComments = value;
            }
        }

        public string NetworkDepartmentComments
        {
            get
            {
                return networkDepartmentComments;
            }

            set
            {
                networkDepartmentComments = value;
            }
        }

        public string NewDepartmentComments
        {
            get
            {
                return newDepartmentComments;
            }

            set
            {
                newDepartmentComments = value;
            }
        }

        public string PersonnelDepartmentComments
        {
            get
            {
                return personnelDepartmentComments;
            }

            set
            {
                personnelDepartmentComments = value;
            }
        }

        public string ViceGeneralManager
        {
            get
            {
                return viceGeneralManager;
            }

            set
            {
                viceGeneralManager = value;
            }
        }

        public string ProcessImg
        {
            get
            {
                return processImg;
            }

            set
            {
                processImg = value;
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
