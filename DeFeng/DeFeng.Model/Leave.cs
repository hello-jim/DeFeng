﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Leave
    {
        private int id;
        private Department department;//部门
        private Staff staff;//员工
        private string post;//岗位
        private LeaveType leaveType;//请假类型
        private DateTime leaveDateFrom;
        private DateTime leaveDateTo;
        private float totalLeaveCount;//总共请假天数
        private string leaveReason;//请假原因
        private string attachmentName;//附件
        private string shopownerComments;//店长意见
        private string sceneManager;//现场经理
        private string personnelDepartmentComments;//人事部意见
        private string personnelManager;//人事经理
        private string generalManager;//总经理
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

        public LeaveType LeaveType
        {
            get
            {
                return leaveType;
            }

            set
            {
                leaveType = value;
            }
        }

        public DateTime LeaveDateFrom
        {
            get
            {
                return leaveDateFrom;
            }

            set
            {
                leaveDateFrom = value;
            }
        }

        public DateTime LeaveDateTo
        {
            get
            {
                return leaveDateTo;
            }

            set
            {
                leaveDateTo = value;
            }
        }

        public float TotalLeaveCount
        {
            get
            {
                return totalLeaveCount;
            }

            set
            {
                totalLeaveCount = value;
            }
        }

        public string LeaveReason
        {
            get
            {
                return leaveReason;
            }

            set
            {
                leaveReason = value;
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

        public string GeneralManager
        {
            get
            {
                return generalManager;
            }

            set
            {
                generalManager = value;
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
