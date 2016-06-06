using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class AnnouncementRead
    {
        private int id;
        private Staff staff;
        private Announcement announcement;
        private AnnouncementType announcementType;
        private bool isRead;
        private DateTime lastReadDate;
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

        public Announcement Announcement
        {
            get
            {
                return announcement;
            }

            set
            {
                announcement = value;
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

        public bool IsRead
        {
            get
            {
                return isRead;
            }

            set
            {
                isRead = value;
            }
        }
    }
}
