using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class PermissionType_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<PermissionType> GetPermissionType()
        {
            var list = new List<PermissionType>();
            try
            {
                var sql = "SELECT [ID],[typeName] From PermissionType";
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (read.Read())
                {
                    var obj = new PermissionType();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.TypeName = Convert.IsDBNull(read["typeName"]) ? "" : Convert.ToString(read["typeName"]);
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
