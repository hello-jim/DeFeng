using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class HouseQuality
    {
        private int id;
        private string qualityName;

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

        public string QualityName
        {
            get
            {
                return qualityName;
            }

            set
            {
                this.qualityName = value;
            }
        }
    }
}
