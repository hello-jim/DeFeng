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
    public class Source_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Source> LoadSource(int sourceType)
        {
            List<Source> list = new List<Source>();
            try
            {
                var sql = "SELECT [ID],[sourceName] FROM Source WHERE sourceType=@sourceType";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@sourceType", sourceType));
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new Source();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.SourceName = Convert.ToString(result["sourceName"]);
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
