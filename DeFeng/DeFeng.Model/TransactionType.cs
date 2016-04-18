using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class TransactionType
    {
        private int id;
        private string transactionTypeName;

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

        public string TransactionTypeName
        {
            get
            {
                return transactionTypeName;
            }

            set
            {
                this.transactionTypeName = value;
            }
        }
    }
}
