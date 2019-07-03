using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataLayer;

namespace BusinessLayer
{
    class TransactionBL
    {
        private TransactionDL transactionDL = new TransactionDL();

        public void Create(int accountID, Transaction newTransaction)
        {
            transactionDL.Create(accountID, newTransaction);
        }
        public List<Transaction> GetAll(int accountID)
        {
            var transaction = transactionDL.GetAll(accountID);
            return transaction;
        }
    }
}
