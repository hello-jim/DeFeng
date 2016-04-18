using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class District_BLL
    {
        District_DAL dal = new District_DAL();

        public List<District> LoadDistrict(int cityID)
        {
            List<District> list = new List<District>();
            try
            {
                list = dal.LoadDistrict(cityID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
