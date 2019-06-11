using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JobSearchApi.Utilities
{
    /// <summary>
    /// Utility class
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Hashes the given password
        /// </summary>
        /// <param name="password">The password to be hashed</param>
        /// <returns>The hashed password</returns>
        public static string HashPassword(string password)
        {
            // Create the salt
            const int SIZE = 128, BYTE = 8, LENGTH = 256, ITERATION = 10000;
            var salt = new byte[SIZE / BYTE];

            // Make it random
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, ITERATION, LENGTH / BYTE));
        }
    }
}
