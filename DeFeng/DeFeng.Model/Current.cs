using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Current
    {
        private int id;
        private string currentName;

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

        public string CurrentName
        {
            get
            {
                return currentName;
            }

            set
            {
                currentName = value;
            }
        }
    }
}
