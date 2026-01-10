using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Domain;

namespace Backend.Repositories
{
    public class ProductRepository
    {
        private readonly DataBase dataBase;
        public ProductRepository(DataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<string> InsertProduct(Product product)
        {
            var productCollection = dataBase.GetProductCollection();
            await productCollection.InsertOneAsync(product);
            return product.Id;
        }
    }
}
