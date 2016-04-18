using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class FollowType_DAL
    {
        string sqlConn = Common.CommonClass.GetSysConfig("DeFengDBConStr");

        public List<FollowType> LoadFollowType()
        {
            var list = new List<FollowType>();
            try
            {
                var sql = "SELECT [ID],[typeName] FROM FollowType";
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new FollowType();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.TypeName = Convert.ToString(result["typeName"]);
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
