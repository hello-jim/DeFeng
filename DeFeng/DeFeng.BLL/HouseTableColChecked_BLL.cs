using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseTableColChecked_BLL
    {
        HouseTableColChecked_DAL dal = new HouseTableColChecked_DAL();
        public List<HouseTableColChecked> LoadHouseTableColChecked()
        {
            List<HouseTableColChecked> list = new List<HouseTableColChecked>();
            try
            {
                list = dal.LoadHouseTableColChecked();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int ChangeHouseTableColStatus(HouseTableColChecked col)
        {
            var result = 0;
            try
            {
                result = dal.ChangeHouseTableColStatus(col);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
