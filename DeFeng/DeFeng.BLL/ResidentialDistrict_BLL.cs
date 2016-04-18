using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class ResidentialDistrict_BLL
    {
        ResidentialDistrict_DAL dal = new ResidentialDistrict_DAL();
        public List<ResidentialDistrict> LoadResidentialDistrict()
        {
            List<ResidentialDistrict> list = new List<ResidentialDistrict>();
            try
            {
                list = dal.LoadResidentialDistrict();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
