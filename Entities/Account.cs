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
        public float Balances { get; set; }
        public AccountType Type { get; set; }

        public bool WithDraw(int sum)
        {
            float newBal = Balances - sum;
            if (newBal > 0 || Type == AccountType.BusinessAccount)
            {
                Balances = newBal;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Deposit(int sum)
        {
            Balances += sum;
            return true;
        }
        public Transaction DisplayTransaction(int index)
        {
            return Transactions[index];
        }
        public bool Transfer(Account id, int sum) { return true; }
    }
}
