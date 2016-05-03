using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Country_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Country> LoadCountry()
        {
            List<Country> list = new List<Country>();
            try
            {
                var sql = "SELECT [ID],[chineseName] FROM Country";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Country();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.ChineseName = Convert.ToString(result["chineseName"]);
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
