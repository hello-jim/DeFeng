using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Appliance
    {
        private int id;
        private string applianceName;

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

        public string ApplianceName
        {
            get
            {
                return applianceName;
            }

            set
            {
                applianceName = value;
            }
        }
    }
}
