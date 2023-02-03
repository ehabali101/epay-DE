using System.ComponentModel.DataAnnotations;

namespace RESTServer.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public bool ValidateAge()
        {
            return Age > 18;
        }

    }
}
