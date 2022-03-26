using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace cs451_commerce_bank_project.Controllers.Concerns
{
  public class Hashable
  {
    public static string HashPassword(string password)
    {
      byte[] salt = new byte[128 / 8];

      string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));

      return passwordHash;
    }
  }
}
