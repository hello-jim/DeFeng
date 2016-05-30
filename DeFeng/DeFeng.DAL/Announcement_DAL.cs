using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Model;
using DeFeng.Common;
using System.Data;

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

        public bool CreateAnnouncement(List<int> idArr, Announcement announcement)
        {
            var sql = "INSERT INTO Announcement([staff],[announcement],[announcementType],[isRead],[lastReadDate],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff])";
            //SqlHelper.ExecuteScalar
            //DataTable dt = new DataTable();
            //dt.Columns.Add("staff");
            //dt.Columns.Add("announcement");
            //dt.Columns.Add("announcementType");
            //dt.Columns.Add("isRead");
            //dt.Columns.Add("lastReadDate");
            //dt.Columns.Add("createStaff");
            //dt.Columns.Add("createDate");
            //dt.Columns.Add("lastUpdateDate");
            //dt.Columns.Add("lastUpdateStaff");
            //for (int i = 0; i < idArr.Count; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr[0] = idArr[i];
            //    dr[1] = announcement.ID;
            //    dr[2] = announcement.AnnouncementType != null ? announcement.AnnouncementType.ID : 0;
            //    dr[3] = 0;
            //    dr[4] = null;
            //    dr[5] = announcement.CreateStaff != null ? announcement.CreateStaff.ID : 0;
            //    dr[6] = DateTime.Now;
            //    dr[7] = DateTime.Now;
            //    dr[8] = announcement.LastUpdateStaff != null ? announcement.LastUpdateStaff.ID : 0;
            //    dt.Rows.Add(dr);
            //}

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "AnnouncementRead";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return false;
        }

    }
}
