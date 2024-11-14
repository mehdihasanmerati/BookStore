using Microsoft.AspNetCore.Identity;

namespace AAASecurity.Infrastructure
{
    public class CustomUserValidator : IUserValidator<IdentityUser>
    {
        private readonly string OrganizationEmail = "@BookStore.com";
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            if (!user.Email.EndsWith(OrganizationEmail, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "Invalid Email!",
                    Description = "You should use your organization email"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
