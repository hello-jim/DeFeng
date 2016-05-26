using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class EntrustOverDate_BLL
    {
       
        public List<EntrustOverDate> LoadEntrustOverDate()
        {
            var list = new List<EntrustOverDate>();
            EntrustOverDate_DAL dal = new EntrustOverDate_DAL();
            try
            {
               
                list = dal.LoadEntrustOverDate();
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return list;
        }
    }
}
