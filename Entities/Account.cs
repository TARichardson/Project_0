using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class Account : IAccount
    {
        public int AccountID { get; set; }
        public float InterestRate { get; set; }
        public int PageMax { get; set; }
        public List<Transaction> Transactions { get; set; }
        public virtual float Balances { get; set; }
        public AccountType Type { get; set; }

        public virtual bool WithDraw(float sum)
        {
            float newBal = Balances - sum;
            if (newBal > 0)
            {
                Balances = newBal;
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual bool Deposit(float sum)
        {
            Balances += sum;
            return true;
        }
        public Transaction GetTransaction(int index)
        {
            return Transactions[index];
        }
        public bool Transfer(Account id, float sum) { return true; }
    }
}
