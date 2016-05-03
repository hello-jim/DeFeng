using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Wall_BLL
    {
        Wall_DAL dal = new Wall_DAL();
        public List<Wall> LoadWall()
        {
            List<Wall> list = new List<Wall>();
            try
            {
                list = dal.LoadWall();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
