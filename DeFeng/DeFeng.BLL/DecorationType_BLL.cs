using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class DecorationType_BLL
    {
        DecorationType_DAL dal = new DecorationType_DAL();
        public List<DecorationType> LoadDecorationType()
        {
            List<DecorationType> list = new List<DecorationType>();
            try
            {
                list = dal.LoadDecorationType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
