using System.Security.Cryptography;
using System.Text;

namespace Backend.Services
{
  public class HashingService
  {
    public string GenerateRandomHexString(int byteCount = 16)
    {
      byte[] bytes = new byte[byteCount];
      RandomNumberGenerator.Fill(bytes);
      var sb = new StringBuilder(byteCount * 2);
      foreach (var b in bytes) sb.Append(b.ToString("x2"));
      return sb.ToString();
    }
    public string HashString(string text, string salt = "")
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
