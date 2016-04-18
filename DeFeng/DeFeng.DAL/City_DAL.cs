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
    public class City_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<City> LoadCity(int proID)
        {
            List<City> list = new List<City>();
            try
            {
                var sql = "SELECT [CityID],[CityName],[ProID],[CitySort] FROM [City] WHERE [ProID]=@proID";
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@proID", proID));

                var read = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql, pars.ToArray());
                while (read.Read())
                {
                    City obj = new City();
                    obj.ID = Convert.ToInt32(read["CityID"]);
                    obj.ProID = Convert.ToInt32(read["ProID"]);
                    obj.Name = Convert.ToString(read["CityName"]);
                    
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
