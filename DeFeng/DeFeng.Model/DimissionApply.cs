using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class DimissionApply
    {
        private int id;
        private Staff staff;//员工
        private Department department;//部门
        private DimissionType dimissionType;//离职类型
        private DateTime dimissionDate;//离职日期
        private string dimissionExplanation;//离职说明 
        private string handover;//交接
        private string transferStaff;//交接人
        private string acceptStaff;//接手人
        private DateTime transferDate;//交接日期
        private DateTime acceptDate;//接手日期
        private string attachmentName;//附件名
        private string shopownerComments;//店长意见
        private string sceneManagerComments;//现场经理意见
        private string networkDepartmentComments;//网络部意见
        private string personnelDepartmentComments;//人事部意见
        private string mortgageDepartmentComments;//按揭部意见
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

        public DimissionType DimissionType
        {
            get
            {
                return dimissionType;
            }

            set
            {
                dimissionType = value;
            }
        }

        public DateTime DimissionDate
        {
            get
            {
                return dimissionDate;
            }

            set
            {
                dimissionDate = value;
            }
        }

        public string DimissionExplanation
        {
            get
            {
                return dimissionExplanation;
            }

            set
            {
                dimissionExplanation = value;
            }
        }

        public string Handover
        {
            get
            {
                return handover;
            }

            set
            {
                handover = value;
            }
        }

        public string TransferStaff
        {
            get
            {
                return transferStaff;
            }

            set
            {
                transferStaff = value;
            }
        }

        public string AcceptStaff
        {
            get
            {
                return acceptStaff;
            }

            set
            {
                acceptStaff = value;
            }
        }

        public DateTime TransferDate
        {
            get
            {
                return transferDate;
            }

            set
            {
                transferDate = value;
            }
        }

        public DateTime AcceptDate
        {
            get
            {
                return acceptDate;
            }

            set
            {
                acceptDate = value;
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

        public string ShopownerComments
        {
            get
            {
                return shopownerComments;
            }

            set
            {
                shopownerComments = value;
            }
        }

        public string SceneManagerComments
        {
            get
            {
                return sceneManagerComments;
            }

            set
            {
                sceneManagerComments = value;
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

        public string MortgageDepartmentComments
        {
            get
            {
                return mortgageDepartmentComments;
            }

            set
            {
                mortgageDepartmentComments = value;
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
