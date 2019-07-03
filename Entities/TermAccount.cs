using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TermAccount : ITermAccount
    {
        public bool CanOverDraft { get; set; }
        public float InterestRate { get; set; }
        public int PageMax { get; set; }
        List<Transaction> Transactions { get; set; }
        public bool Matrity { get; set; }
        public float Balances { get; set; }
        public AccountType Type { get; set; }

        public bool WithDraw(int sum)
        {
            if (Matrity)
            {
                Balances -= sum;
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
