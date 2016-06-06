using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Common;
using DeFeng.Model;

namespace DeFeng.DAL
{
    public class AnnouncementRead_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

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
                var sql = new StringBuilder("SELECT department,staffName,a.ID,[isRead],[lastReadDate] FROM AnnouncementRead a ");
                sql.Append("LEFT JOIN [Staff] ON a.staff=[Staff].ID ");
                sql.Append(string.Format(" WHERE announcement={0}", announcementId));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString());
                var initDt = new DateTime();//初始日期:00010101
                while (result.Read())
                {
                    var obj = new AnnouncementRead();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.Staff = new Staff
                    {
                        StaffName = Convert.IsDBNull(result["staffName"]) ? "" : Convert.ToString(result["staffName"]),
                        Department = new Department
                        {
                            ID = Convert.IsDBNull(result["department"]) ? 0 : Convert.ToInt32(result["department"])
                        }
                    };
                    obj.IsRead = Convert.IsDBNull(result["isRead"]) ? false : Convert.ToBoolean(result["isRead"]);
                    obj.LastReadDate = Convert.IsDBNull(result["lastReadDate"]) ? initDt : Convert.ToDateTime(result["lastReadDate"]);
                    list.Add(obj);
                }
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
                var sql = string.Format("UPDATE AnnouncementRead SET isRead = {0} WHERE announcemen = {1} AND staff = {2}", true, announcementId, staffID);
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
