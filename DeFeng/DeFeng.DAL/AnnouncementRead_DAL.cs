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
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        public List<int> GetUnreadStaffID(int announcementId)
        {
            var list = new List<int>();
            try
            {
                var sql = string.Format("SELECT staff  FROM AnnouncementRead WHERE announcement={0}", announcementId);
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    list.Add(Convert.IsDBNull(result["staff"]) ? 0 : Convert.ToInt32(result["staff"]));
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UpdateStaffReadStatus()
        {
            var result = false;
            try
            {
                var sql = "UPDATE ";
            }
            catch (Exception ex)
            {
                 
            }
            return result;
        }
    }
}
