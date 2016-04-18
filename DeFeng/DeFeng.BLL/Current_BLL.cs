using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Current_BLL
    {
        Current_DAL dal = new Current_DAL();
        public List<Current> LoadCurrent()
        {
            List<Current> list = new List<Current>();
            try
            {
                list = dal.LoadCurrent();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
