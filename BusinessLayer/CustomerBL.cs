using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class CustomerBL
    {
        CustomerDL customerDL = new CustomerDL();

        public void Create(Customer newCustomer)
        {
            customerDL.Create(newCustomer);
        }

        public Customer Get(int id)
        {
                var customer = customerDL.Get(id);
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
  
        }

        public List<Customer> GetAll()
        {
            var customers = customerDL.GetAll();
            return customers;
        }
    }
}
