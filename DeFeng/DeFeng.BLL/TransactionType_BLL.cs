using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class TransactionType_BLL
    {
        TransactionType_DAL dal = new TransactionType_DAL();
        public List<TransactionType> LoadTransactionType()
        {
            List<TransactionType> list = new List<TransactionType>();
            try
            {
                list = dal.LoadTransactionType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
