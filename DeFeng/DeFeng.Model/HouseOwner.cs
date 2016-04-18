using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class HouseOwner
    {
        private string ownerName;//业主名称
        private string ownerPhone;//业主电话
        private string contacts;//联系人
        private string contactPhone;//联系人电话

        public string OwnerName
        {
            get
            {
                return ownerName;
            }

            set
            {
                ownerName = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return ownerPhone;
            }

            set
            {
                ownerPhone = value;
            }
        }

        public string Contacts
        {
            get
            {
                return contacts;
            }

            set
            {
                contacts = value;
            }
        }

        public string ContactPhone
        {
            get
            {
                return contactPhone;
            }

            set
            {
                contactPhone = value;
            }
        }
    }
}
