using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Source_BLL
    {
        Source_DAL dal = new Source_DAL();
        public List<Source> LoadSource(int sourceType)
        {
            List<Source> list = new List<Source>();
            try
            {
                list = dal.LoadSource(sourceType);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
