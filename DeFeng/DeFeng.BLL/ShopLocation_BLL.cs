using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class ShopLocation_BLL
    {
        ShopLocation_DAL dal = new ShopLocation_DAL();
        public List<ShopLocation> LoadShopLocation()
        {
            List<ShopLocation> list = new List<ShopLocation>();
            try
            {
                list = dal.LoadShopLocation();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
