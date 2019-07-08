using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class LoanAccount : Account, ILoanAccount
    {
        private float _balances = 0;
        public bool LoanTransfered { get; set; }
        public float LoanAmount { get; set; }

        public override float Balances
        {
            get { return LoanAmount - _balances; }
            set {  }
        }
        public bool PayLoad(float sum)
        {
            float oldBalances = Balances;
            _balances += sum;

            Transactions.Add(new Transaction()
            {
                Type = TransactionType.PLD,
                TransactionID = Transactions.Count(),
                Date = DateTime.Now,
                Log = $"The Amount of ${sum} was payed on ${oldBalances} | New Balances ${Balances}"
            });
            return true;
        }
        public override bool WithDraw(float sum)
        {
            Transactions.Add(new Transaction()
            {
                Type = TransactionType.WDW,
                TransactionID = Transactions.Count(),
                Date = DateTime.Now,
                Log = $"Withdrawal can't be made from Loan accounts."
            });
            return false;
        }
    }
}
