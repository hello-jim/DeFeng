using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class ShopArea_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<ShopArea> LoadShopArea()
        {
            List<ShopArea> list = new List<ShopArea>();
            try
            {
                var sql = "SELECT [ID],[shopAreaName] FROM ShopArea";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new ShopArea();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.ShopAreaName = Convert.ToString(result["shopAreaName"]);
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
