using RESTServer.Models;
using System.Collections.Generic;

namespace RESTServer.Repo
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomers();       

        bool Add(IEnumerable<Customer> customers);
    }
}
