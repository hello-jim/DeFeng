using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Furniture_BLL
    {
        Furniture_DAL dal = new Furniture_DAL();
        public List<Furniture> LoadFurniture()
        {
            List<Furniture> list = new List<Furniture>();
            try
            {
                list = dal.LoadFurniture();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
