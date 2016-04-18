using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class HouseStatus
    {
        private int id;
        private string statusName;

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

        public string StatusName
        {
            get
            {
                return statusName;
            }

            set
            {
                this.statusName = value;
            }
        }
    }
}
