using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CommonDomain.Cart
{
    public class AddToProductCartDto
    {
        public string ProductId {  get; set; }  
        public int Productcantitate { get; set; }
         public string UserId { get; set; }


    }
}
