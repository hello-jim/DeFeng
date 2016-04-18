using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CommissionPayType_BLL
    {
        CommissionPayType_DAL dal = new CommissionPayType_DAL();
        public List<CommissionPayType> LoadCommissionPayType()
        {
            List<CommissionPayType> list = new List<CommissionPayType>();
            try
            {
                list = dal.LoadCommissionPayType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
