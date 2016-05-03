using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Intention_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Intention> LoadIntention()
        {
            List<Intention> list = new List<Intention>();
            try
            {
                var sql = "SELECT [ID],[intentionName] FROM Intention";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Intention();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.IntentionName = Convert.ToString(result["intentionName"]);
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
