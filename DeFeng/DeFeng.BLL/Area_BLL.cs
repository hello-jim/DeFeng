using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Area_BLL
    {
        Area_DAL dal = new Area_DAL();
        public List<Area> LoadArea(int disID)
        {
            List<Area> list = new List<Area>();
            try
            {
                list = dal.LoadArea(disID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
