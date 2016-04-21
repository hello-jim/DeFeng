using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Source
    {
        private int id;
        private string sourceName;

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

        public string SourceName
        {
            get
            {
                return sourceName;
            }

            set
            {
                sourceName = value;
            }
        }
    }
}
