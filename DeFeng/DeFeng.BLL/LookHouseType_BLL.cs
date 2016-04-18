using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class LookHouseType_BLL
    {
        LookHouseType_DAL dal = new LookHouseType_DAL();
        public List<LookHouseType> LoadLookHouseType()
        {
            List<LookHouseType> list = new List<LookHouseType>();
            try
            {
                list = dal.LoadLookHouseType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
