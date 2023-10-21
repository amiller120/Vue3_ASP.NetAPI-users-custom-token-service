using System.Security.Cryptography;

namespace fastEndpointTemplate.Helpers
{
    public static class PasswordHelper
    {
        
        public static string HashPassword(string password, out byte[] salt)
        {
            salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            var hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            var storedHashBytes = Convert.FromBase64String(storedPassword);
            var salt = new byte[16];
            Array.Copy(storedHashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000, HashAlgorithmName.SHA256);
            var enteredHash = pbkdf2.GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (storedHashBytes[i + 16] != enteredHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
