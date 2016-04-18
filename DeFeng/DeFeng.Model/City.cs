using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class City
    {
        private int id;
        private string name;
        private int proID;
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int ProID
        {
            get
            {
                return proID;
            }

            set
            {
                proID = value;
            }
        }
    }
}
