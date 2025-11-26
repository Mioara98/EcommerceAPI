using Backend.CommonDomain.Product;
using Backend.CommonDomain.Users;
using Backend.Database;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost("CreateProduct")]
        public async Task<string> CreateProduct(CreateProductDto request)

        {
            Product product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            var ProductCollection = new Backend.Database.DataBase().GetProductCollection();
            await ProductCollection.InsertOneAsync(product);
            return "Produs creat cu succes!";
        }
    }
}
