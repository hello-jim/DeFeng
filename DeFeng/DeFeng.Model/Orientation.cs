using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Orientation
    {
        private int id;
        private string orientationName;

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

        public string OrientationName
        {
            get
            {
                return orientationName;
            }

            set
            {
                this.orientationName = value;
            }
        }
    }
}
