using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class CarPark_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<CarPark> LoadCarPark()
        {
            List<CarPark> list = new List<CarPark>();
            try
            {
                var sql = "SELECT [ID],[name] FROM CarPark";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new CarPark();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.Name = Convert.ToString(result["name"]);
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
