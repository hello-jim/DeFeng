using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseQuality_BLL
    {
        HouseQuality_DAL dal = new HouseQuality_DAL();
        public List<HouseQuality> LoadHouseQuality()
        {
            List<HouseQuality> list = new List<HouseQuality>();
            try
            {
                list = dal.LoadHouseQuality();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
