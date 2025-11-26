using Backend.CommonDomain.Users;
using Backend.Database;
using Backend.Domain;
using Backend.Repositories;
using Backend.Services;
using MongoDB.Driver;

namespace Backend.BusinessLogic.FacadeSystem.UserFacade.Login
{
  public class FacadeLogin
  {
    private readonly DataBase _database;
    private HashingService hashingService;
    private readonly UserRepository userRepository;
    public FacadeLogin(DataBase database,HashingService hashingService, UserRepository userRepository)
    {
      _database = database;
      this.hashingService = hashingService;
      this.userRepository = userRepository;
    }
    public async Task<string> PerfomAction(LoginUserDto request)
    {
      User user = await userRepository.GetUserByEmail(request.Email);
      if (user == null)
      {
        return "Utilizator inexistent!";
      }

      string userpassword = user.Password;
      string hashpassword = hashingService.HashString(request.Password + user.Salt);
      string password = request.Password;
      if (userpassword != hashpassword)
      {
        return "Date invalide!";

      }
      return "Login cu succes!";
    }
  }
}
