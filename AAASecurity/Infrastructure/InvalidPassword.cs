using AAASecurity.Models;
using Microsoft.AspNetCore.Identity;

namespace AAASecurity.Infrastructure
{
    public class InvalidPassword<TUser> : IPasswordValidator<TUser> where TUser : IdentityUser
    {
        private readonly AAADbContext _context;

        public InvalidPassword(AAADbContext context)
        {
            _context = context;
        }
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string? password)
        {
            if (_context.BadPasswords.ToList().Any(c => string.Equals(c.Password, password, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "Invalid Password",
                    Description = "You can not use from the blacklist password!"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
