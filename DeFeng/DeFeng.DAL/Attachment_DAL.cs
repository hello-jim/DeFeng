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
                id= Convert.ToInt32(SqlHelper.ExecuteScalar(sqlConn, System.Data.CommandType.Text, attachmentSql, attachmentSqlPars.ToArray()));
            }
            catch (Exception ex)
            {

            }
            return id;
        }
    }
}
