using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Common;
using DeFeng.Model;

namespace DeFeng.DAL
{
    public class Attachment_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public int AddAttachment(Attachment attachment)
        {
            var id = 0;//附件ID
            try
            {
                var attachmentSql = "INSERT INTO Attachment([attachmentName],[attachmentType],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff]) VALUES(@attachmentName,@attachmentType,@createStaff,@createDate,@lastUpdateDate,@lastUpdateStaff) SELECT @@IDENTITY";
                var attachmentSqlPars = new List<SqlParameter>();
                attachmentSqlPars.Add(new SqlParameter("@attachmentName", attachment.AttachmentName));
                attachmentSqlPars.Add(new SqlParameter("@attachmentType", attachment.AttachmentType));
                attachmentSqlPars.Add(new SqlParameter("@createStaff", attachment.CreateStaff != null ? attachment.CreateStaff.ID : 0));
                attachmentSqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                attachmentSqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                attachmentSqlPars.Add(new SqlParameter("@lastUpdateStaff", attachment.LastUpdateStaff != null ? attachment.LastUpdateStaff.ID : 0));
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlConn, System.Data.CommandType.Text, attachmentSql, attachmentSqlPars.ToArray()));
            }
            catch (Exception ex)
            {

            }
            return id;
        }

        public List<Attachment> LoadAttachment(AttachmentType type, int ofID)
        {
            var list = new List<Attachment>();
            try
            {
                var sql = string.Format("SELECT [ID],[attachmentName],[attachmentType] FROM Attachment WHERE ofID={0} AND attachmentType={1}", ofID, (int)type);
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (read.Read())
                {
                    var obj = new Attachment();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.AttachmentName = Convert.IsDBNull(read["attachmentName"]) ? "" : Convert.ToString(read["attachmentName"]);
                    obj.AttachmentType = (AttachmentType)Convert.ToInt32(read["attachmentType"]);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
