using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Appliance_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Appliance> LoadAppliance()
        {
            List<Appliance> list = new List<Appliance>();
            try
            {
                var sql = "SELECT [ID],[applianceName] FROM Appliance";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Appliance();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.ApplianceName = Convert.ToString(result["applianceName"]);
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
