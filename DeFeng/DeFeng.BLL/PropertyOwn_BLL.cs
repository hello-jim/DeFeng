using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class PropertyOwn_BLL
    {
        PropertyOwn_DAL dal = new PropertyOwn_DAL();
        public List<PropertyOwn> LoadPropertyOwn()
        {
            List<PropertyOwn> list = new List<PropertyOwn>();
            try
            {
                list = dal.LoadPropertyOwn();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
