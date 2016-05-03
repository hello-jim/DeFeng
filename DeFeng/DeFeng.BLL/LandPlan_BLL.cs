using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class LandPlan_BLL
    {
        LandPlan_DAL bll = new LandPlan_DAL();
        public List<LandPlan> LoadLandPlan()
        {
            List<LandPlan> list = new List<LandPlan>();
            try
            {
                list = bll.LoadLandPlan();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
