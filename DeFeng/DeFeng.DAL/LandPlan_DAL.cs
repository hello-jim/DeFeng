using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class LandPlan_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<LandPlan> LoadLandPlan()
        {
            List<LandPlan> list = new List<LandPlan>();
            try
            {
                var sql = "SELECT [ID],[planName] FROM LandPlan";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new LandPlan();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.PlanName = Convert.ToString(result["planName"]);
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
