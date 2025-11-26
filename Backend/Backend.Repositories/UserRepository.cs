using Backend.Database;
using Backend.Domain;
using MongoDB.Driver;

namespace Backend.Repositories
{
  public class UserRepository
  {
    private readonly DataBase dataBase;
    public UserRepository(DataBase dataBase)
    {
      this.dataBase = dataBase;
    }

    public void UpdateUser(User user)
    {
      var userCollection = dataBase.GetUsersCollection();
      var filter = Builders<User>.Filter.Eq("Id", user.Id);
      userCollection.ReplaceOne(filter, user);
    }
    public async Task<string> InsertUser(User user)
    {
      var userCollection = dataBase.GetUsersCollection();
      await userCollection.InsertOneAsync(user);
      return user.Id;
    }

    public async Task<User> GetUserByEmail(string email)
    {
      var userCollection = dataBase.GetUsersCollection();
      var filter = Builders<User>.Filter.Eq("Email", email);
      return await userCollection.Find(filter).FirstOrDefaultAsync();
    }
  }
}
