using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Users
{
    public class Address
    {
        public string Id {  get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public int? ApartmentNumber { get; set; }
        public int? BlocNumber { get; set; }

    }
}
