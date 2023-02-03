using RESTSimulator.Data;
using RESTSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTSimulator
{
    internal class Simulator
    {
        Appendix appendix;

        public Simulator()
        {
            appendix = new Appendix();
        }

        private int GetRandmAge()
        {
            Random random = new Random();
            return random.Next(10, 91);
        }

        private int GetRandomNumber(int length)
        {
            Random random = new Random();
            return random.Next(0, length);
        }

        private Customer CreateCustomer()
        {
           return new Customer()
            {
                Id = GetRandomNumber(20),
                FirstName = appendix.FirstNames[GetRandomNumber(appendix.FirstNames.Length)],
                LastName = appendix.LastNames[GetRandomNumber(appendix.LastNames.Length)],
                Age = GetRandmAge()
            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List < Customer > customers = new List<Customer>();
            int count = GetRandomNumber(5);
            if (count == 0)
                count++;
            for(int i = 0; i< count; i++)
            {
                customers.Add(CreateCustomer());
            }

            return customers;
        }

    }
}
