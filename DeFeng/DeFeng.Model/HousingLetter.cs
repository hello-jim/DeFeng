using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class HousingLetter
    {
        private int id;
        private string letterName;

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

        public string LetterName
        {
            get
            {
                return letterName;
            }

            set
            {
                this.letterName = value;
            }
        }
    }
}
