using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable, XmlRoot("Customers")]
    public class Customer
    {
        [XmlAttribute("CustomerID")]
        int CustomerID { get; set; }
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }
        [XmlAttribute("LastName")]
        public string LastName { get; set; }
        public int PageMax { get; set; }
        public Account CurrentAccount { get; set; }
        public List<Account> Accounts { get; set; }
        public bool OpenAccount(Account newAccount) { return true; }
        public bool CloseAccount(int id) { return true; }
        public Account DisplayAccounts(int index)
        {
            return Accounts[index];
        }
    }
}
