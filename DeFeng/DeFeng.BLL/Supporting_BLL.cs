using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Supporting_BLL
    {
        Supporting_DAL dal = new Supporting_DAL();
        public List<Supporting> LoadSupporting()
        {
            List<Supporting> list = new List<Supporting>();
            try
            {
                list = dal.LoadSupporting();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
