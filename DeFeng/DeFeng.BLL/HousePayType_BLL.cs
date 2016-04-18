using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HousePayType_BLL
    {
        HousePayType_DAL dal = new HousePayType_DAL();
        public List<HousePayType> LoadHousePayType()
        {
            List<HousePayType> list = new List<HousePayType>();
            try
            {
                list = dal.LoadHousePayType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
