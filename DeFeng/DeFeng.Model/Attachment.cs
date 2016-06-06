using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Attachment
    {
        private int id;
        private string attachmentName;//附件名
        private AttachmentType attachmentType;//附件类型
        private int ofID;//所属ID
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

        public AttachmentType AttachmentType
        {
            get
            {
                return attachmentType;
            }

            set
            {
                attachmentType = value;
            }
        }

        public int OfID
        {
            get
            {
                return ofID;
            }

            set
            {
                ofID = value;
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

    public enum AttachmentType
    {
        Announcement = 1
    }
}
