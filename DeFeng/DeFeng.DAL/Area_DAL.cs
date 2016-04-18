using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Common;
using DeFeng.Model;


namespace DeFeng.DAL
{
    public class Area_DAL
    {
        public List<Area> LoadArea(int disID)
        {
            string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");

            List<Area> list = new List<Area>();
            try
            {
                var sql = "SELECT [ID],[districtID],[areaName] FROM [Area] WHERE [districtID]=@disID";
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@disID", disID));
                var read = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql, pars.ToArray());
                while (read.Read())
                {
                    Area obj = new Area();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.DistrictID = Convert.ToInt32(read["districtID"]);
                    obj.AreaName = Convert.ToString(read["areaName"]);
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
