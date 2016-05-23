using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Announcement_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<Announcement> LoadAnnouncement(int staffID)
        {
            var list = new List<Announcement>();
            try
            {
                var sql = "SELECT a.[ID],[typeName],[message],[attachmentName],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff] Announcement a LEFT JOIN [Announcement] ON a.announcement=[Announcement].ID LEFT JOIN [Staff] ON a.staff=[Staff].ID WHERE ID IN( SELECT TOP 7 announcement FROM AnnouncementUnread WHERE staff=@staffID  ORDER BY CreateDate) ";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@staffID", staffID));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new Announcement();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.AttachmentName = Convert.IsDBNull(result["attachmentName"]) ? "" : Convert.ToString(result["attachmentName"]);
                    obj.Message = Convert.IsDBNull(result["message"]) ? "" : Convert.ToString(result["message"]);
                    obj.AnnouncementType = new AnnouncementType
                    {
                        TypeName = Convert.IsDBNull(result["typeName"]) ? "" : Convert.ToString(result["typeName"])
                    };
                    obj.CreateStaff = new Staff
                    {
                        StaffName = Convert.IsDBNull(result["staffName"]) ? "" : Convert.ToString(result["staffName"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
