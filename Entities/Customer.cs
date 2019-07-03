using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Utility;

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
        public IAccount CurrentAccount { get; set; }
        public List<IAccount> Accounts { get; set; }
        public bool OpenAccount(IAccount newAccount)
        {
            Accounts.Add(newAccount);
            CurrentAccount = newAccount;
            return true;
        }

        public bool CloseAccount(int id)
        {
            if (CurrentAccount == Accounts[id])
            {
                CurrentAccount = null;
            }
            Accounts.RemoveAt(id);
            if(CurrentAccount == null && Accounts.Count() != 0)
            {
                CurrentAccount = Accounts[0];
            }
            return true;
        }
        public IAccount DisplayAccounts(int index)
        {
            return Accounts[index];
        }
    }
}
