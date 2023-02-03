using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RESTServer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace RESTServer.Repo
{
    
    public class CustomerRepo : ICustomerRepo
    {
        List<Customer> _customers;

        public CustomerRepo() {
            _customers = LoadCustomers();
        }   

        private List<Customer> LoadCustomers()
        {
            string json = System.IO.File.ReadAllText("data\\customers.json");
            return JsonConvert.DeserializeObject<List<Customer>>(json);

        }

        private void AddCustomer(Customer customer)
        {
            int i = 0;
            while (i < _customers.Count && (_customers[i].LastName.CompareTo(customer.LastName) < 0 ||
                                           (_customers[i].LastName == customer.LastName &&
                                            _customers[i].FirstName.CompareTo(customer.FirstName) < 0)))
            {
                i++;
            }
            _customers.Insert(i, customer);
        }

        public bool Add(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                var errors = new List<string>();
                if (string.IsNullOrEmpty(customer.FirstName))
                {
                    errors.Add("First name is empty");         
                }

                if (string.IsNullOrEmpty(customer.LastName))
                {
                    errors.Add("Last name is empty");
                }

                if (customer.Age <= 18)
                {
                    errors.Add("Age should be above 18");
                }

                var existCust = _customers.Where(c => c.Id == customer.Id).FirstOrDefault();
                if (existCust != null)
                {
                    errors.Add("customer Id is already exist");
                }

                if (errors.Count > 0)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(string.Join(", ", errors)),
                        ReasonPhrase = string.Format("customer not in correct format {0}", customer.Id)
                    };
                    throw new HttpResponseException(resp);
                }

                AddCustomer(customer);
            }

            return true;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(_customers);

            System.IO.File.WriteAllText("data\\customers.json", json);
        }
    }
}
