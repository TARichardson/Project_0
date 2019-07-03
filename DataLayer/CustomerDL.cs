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
            try
            {
                // Connect to DB, search for record with matching id.
                Customer cust = new Customer()
                {
                    Id = id,
                    Firstname = "Fred",
                    Lastname = "Smith"
                };

                //throw new Exception("Cannot connect to the Database.");
                throw new MyCustomException("This is my custom exception.");

                return cust;
            }
            catch (Exception ex)
            {
                // Log the details of the exception.
                throw;
                //return null;
            }
        }
        public List<Customer> GetAll()
        {
            // Connect to the DB and fetch all Customer records.
            List<Customer> customerList = new List<Customer>()
            {
                new Customer { Id=101, Firstname="John", Lastname="Smith" },
                new Customer { Id=102, Firstname="Mary", Lastname="Jane" },
                new Customer { Id=103, Firstname="Fred", Lastname="Smith" },
                new Customer { Id=104, Firstname="Neo", Lastname="Anderson" },
                new Customer { Id=105, Firstname="Ajay", Lastname="Singala" }
            };

            return customerList;
        }
    }
}
