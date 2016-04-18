using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseStatus_BLL
    {
        HouseStatus_DAL dal = new HouseStatus_DAL();
        public List<HouseStatus> LoadHouseStatus()
        {
            List<HouseStatus> list = new List<HouseStatus>();
            try
            {
                list = dal.LoadHouseStatus();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
