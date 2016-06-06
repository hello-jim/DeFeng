using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class AnnouncementRead_BLL
    {
        AnnouncementRead_DAL dal = new AnnouncementRead_DAL();
        /// <summary>
        /// 获取公告读取状态
        /// </summary>
        /// <param name="announcementId">公告ID</param>
        /// <returns></returns>
        public List<AnnouncementRead> GetAnnouncementRead(int announcementId)
        {
            var list = new List<AnnouncementRead>();
            try
            {
                list = dal.GetAnnouncementRead(announcementId);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 修改员工公告状态
        /// </summary>
        /// <param name="announcementId">公告ID</param>
        /// <param name="staffID">员工ID</param>
        /// <returns></returns>
        public bool UpdateStaffReadStatus(int announcementId, int staffID)
        {
            var result = false;
            try
            {
                result = dal.UpdateStaffReadStatus(announcementId, staffID);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
