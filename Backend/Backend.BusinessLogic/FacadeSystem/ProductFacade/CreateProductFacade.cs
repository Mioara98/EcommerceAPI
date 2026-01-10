using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BusinessLogic.Factory;
using Backend.CommonDomain.Product;
using Backend.CommonDomain.Users;
using Backend.Domain;
using Backend.Repositories;

namespace Backend.BusinessLogic.FacadeSystem.ProductFacade
{
    public class CreateProductFacade
    {
        private readonly ProductRepository productRipository;
        private readonly ProductFactory productFactory;

        public CreateProductFacade(ProductRepository productRepository, ProductFactory productFactory)
        {
            this.productRipository= productRepository;
            this.productFactory = productFactory;

        }
        public async Task<string> PerfomAction(CreateProductDto request)
        {
            Product product = this.productFactory.ToProduct(request);
            await this.productRipository.InsertProduct(product);
            return product.Id;
        }
    }
}

   