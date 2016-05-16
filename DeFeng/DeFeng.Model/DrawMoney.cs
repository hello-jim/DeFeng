using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class DrawMoney
    {
        private int id;
        private Department drawMoneyDepartment;//领款部门 
        private string moneyUse;//用途
        private decimal money;//金额
        private string mark;//送审标识
        private Staff createStaff;
        private DateTime createDate;
        private DateTime lastUpdateDate;
        private Staff lastUpdateStaff;

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

        public Department DrawMoneyDepartment
        {
            get
            {
                return drawMoneyDepartment;
            }

            set
            {
                drawMoneyDepartment = value;
            }
        }

        public string MoneyUse
        {
            get
            {
                return moneyUse;
            }

            set
            {
                moneyUse = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public string Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }

        public Staff CreateStaff
        {
            get
            {
                return createStaff;
            }

            set
            {
                createStaff = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }

            set
            {
                createDate = value;
            }
        }

        public DateTime LastUpdateDate
        {
            get
            {
                return lastUpdateDate;
            }

            set
            {
                lastUpdateDate = value;
            }
        }

        public Staff LastUpdateStaff
        {
            get
            {
                return lastUpdateStaff;
            }

            set
            {
                lastUpdateStaff = value;
            }
        }
    }
}
