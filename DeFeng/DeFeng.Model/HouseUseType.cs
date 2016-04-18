using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class HouseUseType
    {
        private int id;
        private string typeName;

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

        public string TypeName
        {
            get
            {
                return typeName;
            }

            set
            {
                this.typeName = value;
            }
        }
    }
}
