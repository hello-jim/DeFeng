using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Intention_BLL
    {
        Intention_DAL dal = new Intention_DAL();
        public List<Intention> LoadIntention()
        {
            List<Intention> list = new List<Intention>();
            try
            {
                list = dal.LoadIntention();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
