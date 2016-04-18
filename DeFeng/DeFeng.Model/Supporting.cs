using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Supporting
    {
        private int id;
        private string itemValue;

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

        public string ItemValue
        {
            get
            {
                return itemValue;
            }

            set
            {
                itemValue = value;
            }
        }
    }
}
