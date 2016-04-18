using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class Orientation_BLL
    {
        Orientation_DAL dal = new Orientation_DAL();
        public List<Orientation> LoadOrientation()
        {
            List<Orientation> list = new List<Orientation>();
            try
            {
                list = dal.LoadOrientation();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
