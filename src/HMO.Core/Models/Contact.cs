using System.ComponentModel.DataAnnotations;

namespace HMO.Core.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
