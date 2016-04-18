using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Appliance_BLL
    {
        Appliance_DAL dal = new Appliance_DAL();
        public List<Appliance> LoadAppliance()
        {
            List<Appliance> list = new List<Appliance>();
            try
            {
                list = dal.LoadAppliance();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
