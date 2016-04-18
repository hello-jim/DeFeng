using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseUseType_BLL
    {
        HouseUseType_DAL dal = new HouseUseType_DAL();
        public List<HouseUseType> LoadHouseUseType()
        {
            List<HouseUseType> list = new List<HouseUseType>();
            try
            {
                list = dal.LoadHouseUseType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
