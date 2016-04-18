using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Province_BLL
    {
        Province_DAL dal = new Province_DAL();

        public List<Province> LoadProvince()
        {
            List<Province> list = new List<Province>();
            try
            {
                list = dal.LoadProvince();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
