using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Current_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Current> LoadCurrent()
        {
            List<Current> list = new List<Current>();
            try
            {
                var sql = "SELECT [ID],[currentName] FROM [Current]";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Current();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.CurrentName = Convert.ToString(result["currentName"]);
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
