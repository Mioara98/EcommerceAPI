using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Backend.CommonDomain.Users;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Usercontrollers: ControllerBase
    {
        [HttpPost("LoginUser")]
        public async Task<string> LoginUser(LoginUserDto request)
        {
            var filter = Builders<User>.Filter.Eq("Email", request.Email);
            var UserCollection = new Backend.Database.DataBase().GetUsersCollection();
            User user = await new Backend.Database.DataBase().GetUsersCollection().Find(filter).FirstOrDefaultAsync();
            if (user == null)
            {
                return "Utilizator inexistent!";
            }


            string userpassword = user.Password;
            string hashpassword = HashString(request.Password + user.Salt);
            string password = request.Password;
            if (userpassword != hashpassword)
            {
                return "Date invalide!";

            }

            return "Login cu succes!";
        }

        


        [HttpPost("CreateUser")]
        public async Task<string> CreateUser(CreateUserDto request)
        {
            string salt= GenerateRandomHexString(16);
            request.Password = request.Password + salt;
            string hashpassword= HashString(request.Password);
            User user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = hashpassword;
            user.Salt = salt;
            var UserCollection = new Backend.Database.DataBase().GetUsersCollection();
            await UserCollection.InsertOneAsync(user);
            

            return "User creat cu succes!";
        }
        public static string GenerateRandomHexString(int byteCount = 16)
        {
            byte[] bytes = new byte[byteCount];
            RandomNumberGenerator.Fill(bytes);
            // lowercase hex
            var sb = new StringBuilder(byteCount * 2);
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        static string HashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

         
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

               
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }


    }
}
