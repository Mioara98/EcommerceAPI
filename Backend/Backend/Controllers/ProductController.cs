using Backend.BusinessLogic.FacadeSystem.ProductFacade;
using Backend.BusinessLogic.FacadeSystem.UserFacade.Login;
using Backend.BusinessLogic.FacadeSystem.UserFacade.Register;
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
        CreateProductFacade createProductFacade;
        public ProductController(CreateProductFacade createProductFacade)
        {
           this.createProductFacade = createProductFacade;
        }



        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto request)
        {
            var response = await createProductFacade.PerfomAction(request);
            return this.Ok ("Produs creat cu succes!");
        }


        
    }
}
