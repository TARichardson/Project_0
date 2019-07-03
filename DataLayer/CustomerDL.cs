using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataLayer
{
    public class CustomerDL
    {
        public void Create(Customer newCustomer)
        {
            // Connect to the DB and create a new record.
        }

        public Customer Get(int id)
        {

            // Connect to DB, search for record with matching id.

            return new Customer();
        }
        public List<Customer> GetAll()
        {
            // Connect to the DB and fetch all Customer records.
            List<Customer> customerList = new List<Customer>()
            {
            };

            return customerList;
        }
    }
}
