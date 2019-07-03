using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataLayer
{
    public class TransactionDL
    {
        public void Create(int accountID, Transaction newTransaction)
        {
            // create a new Transaction for a Account
        }

        public List<Transaction> GetAll(int accountID)
        {
            List<Transaction> list = new List<Transaction>();
            // get all Transaction record for a Account.


            return list; 
        }

    }
}
