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
    public class District_DAL
    {
        public List<District> LoadDistrict(int cityID)
        {
            string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");

            List<District> list = new List<District>();
            try
            {
                var sql = "SELECT [Id],[DisName],[CityID],[DisSort] FROM [District] WHERE [CityID]=@cityID";
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@cityID", cityID));
                var read = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql, pars.ToArray());
                while (read.Read())
                {
                    District obj = new District();
                    obj.ID = Convert.ToInt32(read["Id"]);
                    obj.CityID = Convert.ToInt32(read["CityID"]);
                    obj.Name = Convert.ToString(read["DisName"]);
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
