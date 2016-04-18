using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Supporting_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Supporting> LoadSupporting()
        {
            List<Supporting> list = new List<Supporting>();
            try
            {
                var sql = "SELECT [ID],[itemValue] FROM Supporting";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Supporting();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.ItemValue = Convert.ToString(result["itemValue"]);
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
