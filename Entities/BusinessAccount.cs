using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class BusinessAccount : Account
    {
        public override bool WithDraw(float sum)
        {
            Transactions.Add(new Transaction()
            {
                Type = TransactionType.WDW,
                TransactionID = Transactions.Count(),
                Date = DateTime.Now,
                Log = $"Withdrawal of ${sum} from ${base.Balances} | New Balances {base.Balances - sum}"
            });
            base.Balances -= sum;
                return true;
        }

        public override void AccountUpdate()
        {
            DateTime current = DateTime.Now;

            if (current >= NextStatment)
            {
                EndingBalance = Balances;
                if (EndingBalance < 0)
                {

                    float sum = EndingBalance * (InterestRate / 100);
                    float oldBalances = Balances;
                    Balances -= sum;
                    Transactions.Add(new Transaction()
                    {
                        Type = TransactionType.INR,
                        TransactionID = Transactions.Count(),
                        Date = DateTime.Now,
                        Log = $"Interest added, of the sum of ${sum} to overdraft account of ${oldBalances} | New Balances: ${Balances}"
                    });
                }
                BeginningStatment = current;
                NextStatment = current.AddDays(30);
            }
        }
    }
}
