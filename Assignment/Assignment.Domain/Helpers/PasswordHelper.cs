using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Helpers
{
    public class PasswordHelper
    {
        public static byte[] GetSecureSalt()
        {
            int numberSercuriry = 123456;
            byte[] intBytes = BitConverter.GetBytes(numberSercuriry);
            Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }
        public static string HashUsingPbkdf2(string password, byte[] salt)
        {
            byte[] derivedKey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, iterationCount: 100000, 32);

            return Convert.ToBase64String(derivedKey);
        }
    }
}
