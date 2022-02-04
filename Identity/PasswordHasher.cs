using System;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

namespace Budgeteer_REST.Identity
{
    public class PasswordHasher : IPasswordHasher<AppUser>
    {
        public string HashPassword(AppUser user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}