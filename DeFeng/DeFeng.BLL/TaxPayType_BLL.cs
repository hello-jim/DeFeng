using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class TaxPayType_BLL
    {
        TaxPayType_DAL dal = new TaxPayType_DAL();
        public List<TaxPayType> LoadTaxPayType()
        {
            List<TaxPayType> list = new List<TaxPayType>();
            try
            {
                list = dal.LoadTaxPayType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
