using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataLayer;

namespace BusinessLayer
{
    public class AccountBL
    {
        AccountDL accountDL = new AccountDL();

        public void Create(int customerID, TermAccount newAccount)
        {
            accountDL.Create(customerID, newAccount);
        }
        public void Create(int customerID, Account newAccount)
        {
            accountDL.Create(customerID, newAccount);

        }
        public List<IAccount> GetAll(int customerID)
        {
            var accounts = accountDL.GetAll(customerID);
            return accounts;
        }
    }
}
