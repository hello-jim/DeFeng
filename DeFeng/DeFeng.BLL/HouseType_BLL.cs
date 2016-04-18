using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class HouseType_BLL
    {
        HouseType_DAL dal = new HouseType_DAL();
        public List<HouseType> LoadHouseType()
        {
            List<HouseType> list = new List<HouseType>();
            try
            {
                list = dal.LoadHouseType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
