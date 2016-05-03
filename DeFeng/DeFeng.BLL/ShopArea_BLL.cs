using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class ShopArea_BLL
    {
        ShopArea_DAL dal = new ShopArea_DAL();
        public List<ShopArea> LoadShopArea()
        {
            List<ShopArea> list = new List<ShopArea>();
            try
            {
                list = dal.LoadShopArea();  
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
