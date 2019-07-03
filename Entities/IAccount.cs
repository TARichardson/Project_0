using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public interface IAccount
    {
        int AccountID { get; set; }
        float InterestRate { get; set; }
        int PageMax { get; set; }
        List<Transaction> Transactions { get; set; }
        float Balances { get; set; }
        AccountType Type { get; set; }

        bool WithDraw(float sum);
        bool Deposit(float sum);
        Transaction DisplayTransaction(int index);
        bool Transfer(Account id, float sum);
    }
}
