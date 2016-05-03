using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CarPark_BLL
    {
        CarPark_DAL dal = new CarPark_DAL();
        public List<CarPark> LoadCarPark()
        {
            List<CarPark> list = new List<CarPark>();
            try
            {
                list = dal.LoadCarPark();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
