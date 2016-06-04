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
            var nowDateTime = DateTime.Now;
            var sql = "INSERT INTO Announcement([announcementType],[message],[attachmentName],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff]) VALUES(@announcementType,@message,@attachmentName,@createStaff,@createDate,@lastUpdateDate,@lastUpdateStaff) SELECT @@IDENTITY";
            var sqlPars = new List<SqlParameter>();
            sqlPars.Add(new SqlParameter("@announcementType", announcement.AnnouncementType != null ? announcement.AnnouncementType.ID : 0));
            sqlPars.Add(new SqlParameter("@message", announcement.Message));
            sqlPars.Add(new SqlParameter("@attachmentName", announcement.AttachmentName));
            sqlPars.Add(new SqlParameter("@createStaff", announcement.CreateStaff != null ? announcement.CreateStaff.ID : 0));
            sqlPars.Add(new SqlParameter("@createDate", nowDateTime));
            sqlPars.Add(new SqlParameter("@lastUpdateDate", nowDateTime));
            sqlPars.Add(new SqlParameter("@lastUpdateStaff", announcement.LastUpdateStaff != null ? announcement.LastUpdateStaff.ID : 0));
            var id = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlConn, CommandType.Text, sql, sqlPars.ToArray()));
            #region 批插入
            DataTable dt = new DataTable();
            dt.Columns.Add("staff");
            dt.Columns.Add("announcement");
            dt.Columns.Add("announcementType");
            dt.Columns.Add("isRead");
            dt.Columns.Add("lastReadDate");
            dt.Columns.Add("createStaff");
            dt.Columns.Add("createDate");
            dt.Columns.Add("lastUpdateDate");
            dt.Columns.Add("lastUpdateStaff");
            for (int i = 0; i < idArr.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = idArr[i];
                dr[1] = id;
                dr[2] = announcement.AnnouncementType != null ? announcement.AnnouncementType.ID : 0;
                dr[3] = false;
                dr[4] = announcement.LastReadDate;
                dr[5] = announcement.CreateStaff != null ? announcement.CreateStaff.ID : 0;
                dr[6] = nowDateTime;
                dr[7] = nowDateTime;
                dr[8] = announcement.LastUpdateStaff != null ? announcement.LastUpdateStaff.ID : 0;
                dt.Rows.Add(dr);
            }

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
            #endregion
            return true;
        }

        /// <summary>
        /// 根据员工ID获取公告
        /// </summary>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public List<Announcement> GetAnnouncementByStaff(int staffID)
        {
            var announcement = new List<Announcement>();
            try
            {
                var sql = new StringBuilder("SELECT s1.ID AS createStaffID,s1.staffName AS createStaffName,s2.ID AS lastUpdateStaffID,s2.staffName AS lastUpdateStaffName,[ID],[announcementType],[message],[attachmentName],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff] FROM Announcement a ");
                sql.Append("LEFT JOIN [AnnouncementType] ON a.announcementType=[AnnouncementType].ID ");
                sql.Append("LEFT JOIN [Staff] s1 ON a.createStaff=s1.ID ");
                sql.Append("LEFT JOIN [Staff] s2 ON a.lastUpdateStaff=s2.ID ");
                sql.Append(" WHERE ");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@staff", staffID));
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString(), pars.ToArray());
                while (result.Read())
                {
                    var obj = new Announcement();
                    obj.ID = Convert.ToInt32(result["ID"]);
                }
            }
            catch (Exception ex)
            {

            }
            return announcement;
        }

        public bool UpdateAnnouncement(Announcement announcement)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Announcement SET [announcementType]=@announcementType,[message]=@message,[attachmentName]=@attachmentName,[lastUpdateDate]=@lastUpdateDate,[lastUpdateStaff]=@lastUpdateStaff WHERE ID=@ID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@announcementType", announcement.ID));
                pars.Add(new SqlParameter("@message", announcement.Message));
                pars.Add(new SqlParameter("@attachmentName", announcement.AttachmentName));
                pars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@lastUpdateStaff", announcement.LastUpdateStaff != null ? announcement.LastUpdateStaff.ID : 0));
                pars.Add(new SqlParameter("@ID", announcement.ID));
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteAnnouncement(List<int> idList)
        {
            var result = false;
            try
            {
                var idListStr = String.Join(",", idList);
                var sql = string.Format("DELETE FROM Announcement WHERE ID IN({0})", idListStr);
                result = SqlHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}
