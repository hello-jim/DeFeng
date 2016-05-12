using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class FormalStaffApply
    {
        private int id;
        private Staff staff;
        private string post;
        private Department department;
        private decimal probationPeriodWages;//转正前薪水
        private decimal formalWages;//转正后薪水
        private DateTime formalDate;//转正日期
        private bool isBuySocialSecurity;//是否买社保
        private City socialSecurityBuyCity;//社保购买城市
        private bool isObeyAllocation;//是否服从调配
        private string formalReason;//转正理由
        private string attachmentName;//附件
        private string shopownerComments;//店长意见
        private string sceneManagerComments;//现场经理意见
        private string personnelDepartmentComments;//人事部意见
        private string personnelManager;//人事经理
        private string viceGeneralManager;//副总
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

        public string Post
        {
            get
            {
                return post;
            }

            set
            {
                post = value;
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

        public decimal ProbationPeriodWages
        {
            get
            {
                return probationPeriodWages;
            }

            set
            {
                probationPeriodWages = value;
            }
        }

        public decimal FormalWages
        {
            get
            {
                return formalWages;
            }

            set
            {
                formalWages = value;
            }
        }

        public DateTime FormalDate
        {
            get
            {
                return formalDate;
            }

            set
            {
                formalDate = value;
            }
        }

        public bool IsBuySocialSecurity
        {
            get
            {
                return isBuySocialSecurity;
            }

            set
            {
                isBuySocialSecurity = value;
            }
        }

        public City SocialSecurityBuyCity
        {
            get
            {
                return socialSecurityBuyCity;
            }

            set
            {
                socialSecurityBuyCity = value;
            }
        }

        public bool IsObeyAllocation
        {
            get
            {
                return isObeyAllocation;
            }

            set
            {
                isObeyAllocation = value;
            }
        }

        public string FormalReason
        {
            get
            {
                return formalReason;
            }

            set
            {
                formalReason = value;
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

        public string PersonnelManager
        {
            get
            {
                return personnelManager;
            }

            set
            {
                personnelManager = value;
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
