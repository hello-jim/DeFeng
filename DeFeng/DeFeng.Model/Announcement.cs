using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Announcement
    {
        private int id;
        private AnnouncementType announcementType;
        private string message;
        private string attachmentName;
        private List<string> pushRange;//推送范围
        private DateTime lastReadDate;//截止查看时间
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

        public AnnouncementType AnnouncementType
        {
            get
            {
                return announcementType;
            }

            set
            {
                announcementType = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
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

        public List<string> PushRange
        {
            get
            {
                return pushRange;
            }

            set
            {
                pushRange = value;
            }
        }

        public DateTime LastReadDate
        {
            get
            {
                return lastReadDate;
            }

            set
            {
                lastReadDate = value;
            }
        }
    }
}
