using Backend.BusinessLogic.Factory;
using Backend.CommonDomain.Users;
using Backend.Database;
using Backend.Domain;
using Backend.Repositories;
using Backend.Services;

namespace Backend.BusinessLogic.FacadeSystem.UserFacade.Register
{
  public class RegisterUserFacade
  {
    private readonly UserRepository userRepository;
    private readonly UserFactory userFactory;

    public RegisterUserFacade(DataBase database, UserRepository userRepository, UserFactory userFactory)
    {
      this.userRepository = userRepository;
      this.userFactory = userFactory;
    }
    public async Task<string> PerfomAction(CreateUserDto request)
    {
      User user = this.userFactory.ToUser(request);
      await this.userRepository.InsertUser(user);
      return user.Id;
    }
  }
}
