using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class LoanAccount : ILoanAccount
    {
        public int AccountID { get; set; }
        public float InterestRate { get; set; }
        public int PageMax { get; set; }
        public List<Transaction> Transactions { get; set; }
        private float _balances = 0;
        public bool LoanTransfered { get; set; }

        public float Balances
        {
            get { return LoanAmount - _balances; }
            set {  }
        }
        public AccountType Type { get; set; }
        public float LoanAmount { get; set; }
        public bool PayLoad(float sum)
        {
            _balances += sum;
            return true;
        }
        public bool WithDraw(float sum)
        {
                return false;
        }
        public bool Deposit(float sum)
        {
            Balances += sum;
            return true;
        }
        public Transaction DisplayTransaction(int index)
        {
            return Transactions[index];
        }
        public bool Transfer(Account id, float sum) { return true; }
    }
}
