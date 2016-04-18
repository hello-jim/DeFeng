using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class EntrustType_BLL
    {
        EntrustType_DAL dal = new EntrustType_DAL();
        public List<EntrustType> LoadEntrustType()
        {
            List<EntrustType> list = new List<EntrustType>();
            try
            {
                list = dal.LoadEntrustType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
