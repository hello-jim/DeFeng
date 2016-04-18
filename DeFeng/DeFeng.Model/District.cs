using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
   public class District
    {
        private int id;
        private string name;
        private int cityID;

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

        public int CityID
        {
            get
            {
                return cityID;
            }

            set
            {
                cityID = value;
            }
        }
    }
}
