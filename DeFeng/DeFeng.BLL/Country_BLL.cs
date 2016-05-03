using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Country_BLL
    {
        Country_DAL dal = new Country_DAL();
        public List<Country> LoadCountry()
        {
            List<Country> list = new List<Country>();
            try
            {
                list = dal.LoadCountry();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
