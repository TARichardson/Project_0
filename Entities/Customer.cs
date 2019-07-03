using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PageMax { get; set; }
        public Account CurrentAccount { get; set; }
        private List<Account> _accounts;
        public bool OpenAccount(Account newAccount) { return true; }
        public bool CloseAccount(int id) { return true; }
        public List<Account> DisplayAccounts(int page = 1)
        {
            //List<Account> displayAccounts = new List<Account>();

            return new List<Account>();
        }
    }
}
