using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HousingLetter_BLL
    {
        HousingLetter_DAL dal = new HousingLetter_DAL();
        public List<HousingLetter> LoadHousingLetter()
        {
            List<HousingLetter> list = new List<HousingLetter>();
            try
            {
                list = dal.LoadHousingLetter();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
