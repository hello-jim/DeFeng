using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class ResidentialDistrict_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<ResidentialDistrict> LoadResidentialDistrict()
        {
            List<ResidentialDistrict> list = new List<ResidentialDistrict>();
            try
            {
                var sql = "SELECT [ID],[name] FROM ResidentialDistrict";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new ResidentialDistrict();
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
