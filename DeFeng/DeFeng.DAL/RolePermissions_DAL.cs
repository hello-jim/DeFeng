using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;
using System.Data;
using System.Data.SqlClient;

namespace DeFeng.DAL
{
    public class RolePermissions_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<Permission> GetRolePermissionsByRoleID(int roleID)
        {
            var list = new List<Permission>();
            try
            {
                var sql = new StringBuilder("SELECT Permission.ID AS permissionID, permissionName,Permission.description AS permissionDescription FROM RolePermissions r");
                sql.Append(" LEFT JOIN Permission ON r.permission=Permission.ID ");
                sql.Append(string.Format(" roleID={0}", roleID));
                var read = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString());
                while (read.Read())
                {
                    var obj = new Permission();
                    obj.ID = Convert.ToInt32(read["permissionID"]);
                    obj.PermissionName = Convert.IsDBNull(read["permissionName"]) ? "" : Convert.ToString(read["permissionName"]);
                    obj.Description = Convert.IsDBNull(read["permissionDescription"]) ? "" : Convert.ToString(read["permissionDescription"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex) { }
            return list;
        }

        public bool AddRolePermission(int roleID, int loginStaffID, List<int> permissionIDList)
        {
            var result = false;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("roleID");
                dt.Columns.Add("permissionID");
                dt.Columns.Add("createStaff");
                dt.Columns.Add("createDate");
                dt.Columns.Add("lastUpdateDate");
                dt.Columns.Add("lastUpdateStaff");
                for (int i = 0; i < permissionIDList.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = roleID;
                    dr[1] = permissionIDList[i];
                    dr[2] = loginStaffID;
                    dr[3] = DateTime.Now;
                    dr[4] = DateTime.Now;
                    dr[5] = loginStaffID;
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
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteRolePermission(int roleID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM RolePermissions WHERE roleID={0}", roleID);
                result = SqlHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
