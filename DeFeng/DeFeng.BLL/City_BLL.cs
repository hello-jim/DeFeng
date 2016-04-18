using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class City_BLL
    {
        City_DAL dal = new City_DAL();

        public List<City> LoadCity(int proID)
        {
            List<City> list = new List<City>();
            try
            {
                list = dal.LoadCity(proID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
