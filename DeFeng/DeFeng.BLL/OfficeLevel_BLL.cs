using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class OfficeLevel_BLL
    {
        OfficeLevel_DAL dal = new OfficeLevel_DAL();
        public List<OfficeLevel> LoadOfficeLevel()
        {
            List<OfficeLevel> list = new List<OfficeLevel>();
            try
            {
                list = dal.LoadOfficeLevel();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
