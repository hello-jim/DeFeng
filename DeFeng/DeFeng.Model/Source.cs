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
        private int sourceType;

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

        public int SourceType
        {
            get
            {
                return sourceType;
            }

            set
            {
                sourceType = value;
            }
        }
    }
}
