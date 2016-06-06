using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Announcement_BLL
    {
        Announcement_DAL dal = new Announcement_DAL();
        public List<Announcement> LoadAnnouncement(int staffID)
        {
            var list = new List<Announcement>();
            Announcement_DAL dal = new Announcement_DAL();
            try
            {
                list = dal.LoadAnnouncement(staffID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int CreateAnnouncement(List<int> idArr, Announcement announcement)
        {
            var id = 0;
            try
            {
                id = dal.CreateAnnouncement(idArr, announcement);
            }
            catch (Exception ex)
            {
            }
            return id;
        }

        /// <summary>
        /// 根据ID获取公告信息
        /// </summary>
        /// <param name="announcementID">公告ID</param>
        /// <returns></returns>
        public Announcement GetAnnouncementByID(int announcementID)
        {
            var announcement = new Announcement();
            try
            {
                announcement = dal.GetAnnouncementByID(announcementID);
            }
            catch (Exception ex)
            {

            }
            return announcement;
        }
    }
}
