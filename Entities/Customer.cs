using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    //[Serializable, XmlRoot("Customer")]
    public class Customer
    {
        [XmlElement(DataType = "int", ElementName = "CustomerID")]
        public int CustomerID { get; set; }
        [XmlElement(DataType = "string", ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(DataType = "string", ElementName = "LastName")]
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
