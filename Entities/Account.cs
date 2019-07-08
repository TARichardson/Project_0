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
        public float StartingBalance { get; set; }
        public float EndingBalance { get; set; }
        public AccountStatus Status { get; set; }
        public DateTime BeginningStatment { get; set; }
        public DateTime NextStatment { get; set; }
        public DateTime AccountOpenDate { get; set; }
        public int PageMax { get; set; }
        public List<Transaction> Transactions { get; set; }
        public virtual float Balances { get; set; }
        public AccountType Type { get; set; }

        public virtual bool WithDraw(float sum)
        {
            float newBal = Balances - sum;
            if (newBal >= 0)
            {
                Transactions.Add(new Transaction()
                {
                    Type = TransactionType.WDW,
                    TransactionID = Transactions.Count(),
                    Date = DateTime.Now,
                    Log = $"Withdrawal of ${sum} from ${Balances} | New Balances ${newBal}"
                });
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
            float oldBalances = Balances;
            Balances += sum;
            Transactions.Add(new Transaction()
            {
                Type = TransactionType.DPS,
                TransactionID = Transactions.Count(),
                Date = DateTime.Now,
                Log = $"Deposit of ${sum} to ${oldBalances} | New Balances ${Balances}"
            });
           
            return true;
        }
        public Transaction GetTransaction(int index)
        {
            return Transactions[index];
        }
        public List<Transaction> TransactionsPage(int page = 1)
        {
            List<Transaction> Result = new List<Transaction>();
            int offsetIndex = (page - 1) * PageMax;
            int offset = Transactions.Count - (page * PageMax);
            for (int index = (Transactions.Count - 1) - offsetIndex; index > -1 && index > offset; index--)
            {
                Result.Add(Transactions[index]);
            }

            return Result;
        }

        public virtual void AccountUpdate()
        {
            DateTime current = DateTime.Now;

            if(current >= NextStatment)
            {
                EndingBalance = Balances;
                float minBalanceHeld = StartingBalance >= EndingBalance ? EndingBalance : StartingBalance;
                float sum = minBalanceHeld * (InterestRate / 100);
                float oldBalances = Balances;
                Balances += sum;
                Transactions.Add(new Transaction()
                {
                    Type = TransactionType.INR,
                    TransactionID = Transactions.Count(),
                    Date = DateTime.Now,
                    Log = $"Interest added, of the sum of ${sum} to ${oldBalances} | New Balances ${Balances}"
                });
                BeginningStatment = current;
                NextStatment = current.AddDays(30);
            }
        }

        public List<Transaction> TransactionRange(DateTime fromDate, DateTime toDate)
        {
            List<Transaction> Result = new List<Transaction>();
            foreach(Transaction transaction in Transactions)
            {
                if(transaction.Date >= fromDate && transaction.Date <= toDate)
                {
                    Result.Add(transaction);
                }
            }
            return Result;
        }

    }
}
