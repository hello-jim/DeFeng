using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Province_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Province> LoadProvince()
        {
            List<Province> list = new List<Province>();
            try
            {
                var sql = "SELECT [ProID],[ProName],[ProSort],[ProRemark] FROM [Province]";
                var read = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (read.Read())
                {
                    Province obj = new Province();
                    obj.ID = Convert.ToInt32(read["ProID"]);
                    obj.Name = Convert.ToString(read["ProName"]);
                    obj.Remark = Convert.ToString(read["ProRemark"]);
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
