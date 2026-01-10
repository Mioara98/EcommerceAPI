using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Serializers;

namespace Backend.Domain.CardDomain
{
    public class Cart
    {
       public List<Item> Items{  get; set; } = new List<Item>();
        
        
    }
}
