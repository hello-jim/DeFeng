using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class HouseQuality_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<HouseQuality> LoadHouseQuality()
        {
            List<HouseQuality> list = new List<HouseQuality>();
            try
            {
                var sql = "SELECT [ID],[qualityName] FROM HouseQuality";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new HouseQuality();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.QualityName = Convert.ToString(result["qualityName"]);
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
