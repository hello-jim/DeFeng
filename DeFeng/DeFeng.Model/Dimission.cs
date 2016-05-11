using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Dimission
    {
        private int id;
        private Staff staff;
        private DimissionType dimissionType;//离职类型
        private DateTime dimissionDate;//离职日期
        private int wagesStandard;//薪资标准
        private string dimissionExplanation;//离职说明
        private string handover;//交接
        private string transferStaff;//交接人
        private string acceptStaff;//接手人
        private DateTime transferDate;//交接日期
        private DateTime acceptDate;//接手日期
        private string attachmentName;//附件名\
        private float sickLeave;//病假
        private float absenteeism;//旷工
        private float arriveLate;//迟到
        private float overtime;//加班
        private float actualAttendance;//实际出勤
        private string shopownerComments;//店长意见
        private string sceneManager;//现场经理
        private string networkDepartmentComments;//网络部意见
        private string mortgageDepartment;//按揭部
        private string fixedAssets;//人事固定资产清点
        private string personnelDepartmentComments;//人事部意见
        private string personnelManager;//人事经理
        private string personnelDepartmentSign;//人事签署
        private decimal wages;//工资
        private decimal subsidy;//补贴
        private decimal deduction;//扣除
        private decimal actualWages;//实发
        private string financeDepartmentComments;//财务部评论
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

        public int WagesStandard
        {
            get
            {
                return wagesStandard;
            }

            set
            {
                wagesStandard = value;
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

        public float SickLeave
        {
            get
            {
                return sickLeave;
            }

            set
            {
                sickLeave = value;
            }
        }

        public float Absenteeism
        {
            get
            {
                return absenteeism;
            }

            set
            {
                absenteeism = value;
            }
        }

        public float ArriveLate
        {
            get
            {
                return arriveLate;
            }

            set
            {
                arriveLate = value;
            }
        }

        public float Overtime
        {
            get
            {
                return overtime;
            }

            set
            {
                overtime = value;
            }
        }

        public float ActualAttendance
        {
            get
            {
                return actualAttendance;
            }

            set
            {
                actualAttendance = value;
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

        public string SceneManager
        {
            get
            {
                return sceneManager;
            }

            set
            {
                sceneManager = value;
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

        public string MortgageDepartment
        {
            get
            {
                return mortgageDepartment;
            }

            set
            {
                mortgageDepartment = value;
            }
        }

        public string FixedAssets
        {
            get
            {
                return fixedAssets;
            }

            set
            {
                fixedAssets = value;
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

        public string PersonnelDepartmentSign
        {
            get
            {
                return personnelDepartmentSign;
            }

            set
            {
                personnelDepartmentSign = value;
            }
        }

        public decimal Wages
        {
            get
            {
                return wages;
            }

            set
            {
                wages = value;
            }
        }

        public decimal Subsidy
        {
            get
            {
                return subsidy;
            }

            set
            {
                subsidy = value;
            }
        }

        public decimal Deduction
        {
            get
            {
                return deduction;
            }

            set
            {
                deduction = value;
            }
        }

        public decimal ActualWages
        {
            get
            {
                return actualWages;
            }

            set
            {
                actualWages = value;
            }
        }

        public string FinanceDepartmentComments
        {
            get
            {
                return financeDepartmentComments;
            }

            set
            {
                financeDepartmentComments = value;
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
