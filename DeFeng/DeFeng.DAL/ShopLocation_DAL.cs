using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class ShopLocation_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<ShopLocation> LoadShopLocation()
        {
            List<ShopLocation> list = new List<ShopLocation>();
            try
            {
                var sql = "SELECT [ID],[item] FROM ShopLocation";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new ShopLocation();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.Item = Convert.ToString(result["item"]);
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
