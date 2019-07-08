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
        public bool PayLoan(float sum)
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
        public override bool Deposit(float sum)
        {
            return PayLoan(sum);
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
        public float Transfer()
        {
            if (!LoanTransfered)
            {
                Transactions.Add(new Transaction()
                {
                    Type = TransactionType.TRF,
                    TransactionID = Transactions.Count(),
                    Date = DateTime.Now,
                    Log = $"Transfer of {LoanAmount} to another account."
                });
                LoanTransfered = true;
                return LoanAmount;
            }
            else
            {
                Transactions.Add(new Transaction()
                {
                    Type = TransactionType.TRF,
                    TransactionID = Transactions.Count(),
                    Date = DateTime.Now,
                    Log = $"You already transfered Loan Amount."
                });
                return 0.0f;
            }
        }
        //public override void AccountUpdate()
        //{
        //    DateTime current = DateTime.Now;

        //    if (current >= NextStatment)
        //    {
        //        EndingBalance = Balances;
        //        float minBalanceHeld = StartingBalance >= EndingBalance ? EndingBalance : StartingBalance;
        //        float sum = minBalanceHeld * (InterestRate / 100);
        //        float oldBalances = Balances;
        //        Balances += sum;
        //        Transactions.Add(new Transaction()
        //        {
        //            Type = TransactionType.INR,
        //            TransactionID = Transactions.Count(),
        //            Date = DateTime.Now,
        //            Log = $"Interest added, of the sum of ${sum} to ${oldBalances} | New Balances ${Balances}"
        //        });
        //        BeginningStatment = current;
        //        NextStatment = current.AddDays(30);
        //    }
        //}

    }
}
