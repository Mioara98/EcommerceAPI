using Backend.BusinessLogic.FacadeSystem.UserFacade.Login;
using Backend.BusinessLogic.FacadeSystem.UserFacade.Register;
using Backend.CommonDomain.Users;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class Usercontrollers : ControllerBase
  {
    FacadeLogin facadeLogin;
    RegisterUserFacade registerUserFacade;
    public Usercontrollers(FacadeLogin facadeLogin, RegisterUserFacade registerUserFacade)
    {
      this.facadeLogin = facadeLogin;
      this.registerUserFacade = registerUserFacade;
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginUser(LoginUserDto request)
    {
      var response = await facadeLogin.PerfomAction(request);
      return this.Ok(response);
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(CreateUserDto request)
    {
      var response = await registerUserFacade.PerfomAction(request);
      return this.Ok(response);
    }
   
  }
}