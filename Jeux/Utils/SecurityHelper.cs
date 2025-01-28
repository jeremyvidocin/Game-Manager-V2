﻿
namespace Jeux.Utils
{
    using BCrypt.Net;
    

    public class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.HashPassword(password, BCrypt.GenerateSalt());
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Verify(password, hashedPassword);
        }
    }
}