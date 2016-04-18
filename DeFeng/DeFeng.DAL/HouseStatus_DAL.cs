using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class HouseStatus_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<HouseStatus> LoadHouseStatus()
        {
            List<HouseStatus> list = new List<HouseStatus>();
            try
            {
                var sql = "SELECT [ID],[statusName] FROM HouseStatus";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new HouseStatus();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.StatusName = Convert.ToString(result["statusName"]);
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
