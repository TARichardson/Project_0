using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataLayer
{
    public class AccountDL
    {
        public void Create(int customerID, Account newAccount)
        {
            // create a new Account record.

        }
        public void Create(int customerID, TermAccount newAccount)
        {
            // create a new Term Account record.

        }
        public List<IAccount> GetAll(int customerID)
        {
            List<IAccount> list = new List<IAccount>();
            // get all Account record for a customer.


            return list;

        }
    }
}
