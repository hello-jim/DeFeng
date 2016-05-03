using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class LandType_BLL
    {
        LandType_DAL dal = new LandType_DAL();
        public List<LandType> LoadLandType()
        {
            List<LandType> list = new List<LandType>();
            try
            {
                list = dal.LoadLandType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
