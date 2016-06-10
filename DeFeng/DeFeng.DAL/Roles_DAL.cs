using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Common;
using DeFeng.Model;

namespace DeFeng.DAL
{
    public class Roles_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<Role> GetRoles()
        {
            var list = new List<Role>();
            try
            {
                var sql = "SELECT [ID],[roleName],[description],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff] FROM Role";
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (read.Read())
                {
                    var obj = new Role();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.RoleName = Convert.IsDBNull(read["roleName"]) ? "" : Convert.ToString(read["roleName"]);
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
