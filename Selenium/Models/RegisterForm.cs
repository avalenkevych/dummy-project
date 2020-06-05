using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Models
{
    public class RegisterForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FirstNameForAddress { get; set; }
        public string LastNameForAddress { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string MobilePhone { get; set; }
        public string Alias { get; set; }
    }
}
