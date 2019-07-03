using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class App
    {
        public Customer CurrentCustomer { get; set; }
        public bool Run { get; set; }
        public bool LogIn(string userName, string password) { return true; }
        public bool LogOut() { return true; }
        public bool Register(Customer newCustormer)
        {
            CurrentCustomer = newCustormer;
            return true;
        }

    }
}
