using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public ulong? MobileNumber { get; set; }
        public ulong? LandlineNumber { get; set; }
        public int? Prefix { get; set; }
        public string Notes { get; set; }

        public Contact()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleNames = string.Empty;
            Notes = string.Empty;
        }
    }
}
