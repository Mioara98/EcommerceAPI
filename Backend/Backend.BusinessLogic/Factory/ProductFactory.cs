using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.CommonDomain.Product;
using Backend.CommonDomain.Users;
using Backend.Domain;
using Backend.Services;

namespace Backend.BusinessLogic.Factory
{
    public class ProductFactory
    {
        

        public Product ToProduct(CreateProductDto creatproductDto)
        {
            Product product = new Product();
            product.Name = creatproductDto.Name;
            product.Description = creatproductDto.Description;
            product.Price = creatproductDto.Price;
            return product;
        }
    }
}
