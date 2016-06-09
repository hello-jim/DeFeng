using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Permission_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<Permission> LoadPermission()
        {
            var list = new List<Permission>();
            try
            {
                var sql = new StringBuilder("SELECT PermissionType.ID AS permissionTypeID,typeName,p.[ID],p.[permissionName],p.[description],p.[createStaff],p.[createDate],p.[lastUpdateDate],p.[lastUpdateStaff] FROM Permission p ");
                sql.Append(" LEFT JOIN PermissionType ON p.permissionType=PermissionType.ID ");
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString());
                while (read.Read())
                {
                    var obj = new Permission();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.PermissionName = Convert.IsDBNull(read["permissionName"]) ? "" : Convert.ToString(read["permissionName"]);
                    obj.Description = Convert.IsDBNull(read["description"]) ? "" : Convert.ToString(read["description"]);
                    obj.PermissionType = new PermissionType
                    {
                        ID = Convert.IsDBNull(read["permissionTypeID"]) ? 0 : Convert.ToInt32(read["permissionTypeID"]),
                        TypeName = Convert.IsDBNull(read["typeName"]) ? "" : Convert.ToString(read["typeName"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Permission> GetPermissionByStaff(int staffID)
        {
            var list = new List<Permission>();
            try
            {
                var sql = new StringBuilder("SELECT Permission.ID AS permissionID,permissionName,description FROM StaffPermission s"); string.Format(" WHERE staffID={0}", staffID);
                sql.Append(" LEFT JOIN Permission ON p.permissionID=Permission.ID ");
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString());
                while (read.Read())
                {
                    var obj = new Permission();
                    obj.ID = Convert.IsDBNull(read["permissionID"]) ? 0 : Convert.ToInt32(read["permissionID"]);
                    obj.PermissionName = Convert.IsDBNull(read["permissionName"]) ? "" : Convert.ToString(read["permissionName"]);
                    obj.Description = Convert.IsDBNull(read["description"]) ? "" : Convert.ToString(read["description"]);
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
