using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseDocumentType_BLL
    {
        HouseDocumentType_DAL dal = new HouseDocumentType_DAL();
        public List<HouseDocumentType> LoadHouseDocumentType()
        {
            List<HouseDocumentType> list = new List<HouseDocumentType>();
            try
            {
                list = dal.LoadHouseDocumentType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
