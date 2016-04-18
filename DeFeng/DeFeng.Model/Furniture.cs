using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Furniture
    {
        private int id;
        private string furnitureName;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string FurnitureName
        {
            get
            {
                return furnitureName;
            }

            set
            {
                furnitureName = value;
            }
        }
    }
}
