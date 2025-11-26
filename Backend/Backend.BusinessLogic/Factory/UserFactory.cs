using Backend.CommonDomain.Users;
using Backend.Domain;
using Backend.Services;

namespace Backend.BusinessLogic.Factory
{
  public class UserFactory
  {
    private readonly HashingService hashingService;
    public UserFactory(HashingService hashingService)
    {
      this.hashingService = hashingService;
    }
    public User ToUser(CreateUserDto createUserDto)
    {
      string salt = hashingService.GenerateRandomHexString(16);
      createUserDto.Password = createUserDto.Password + salt;
      string hashpassword = hashingService.HashString(createUserDto.Password);
      User user = new User();
      user.Name = createUserDto.Name;
      user.Email = createUserDto.Email;
      user.Password = createUserDto.Password;
      user.Salt = salt;
      return user;
    }
  }
}
