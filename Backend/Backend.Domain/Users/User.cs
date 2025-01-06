using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Users
{
    public class User
    {
        public string Email {  get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public  List<Address>  Addresses { get; set; }
        
        
    }
}
