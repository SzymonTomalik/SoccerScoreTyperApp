using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SSTDataAccessLibrary.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SSTWeb.Factory
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<Typer>
    {
        public CustomClaimsFactory(UserManager<Typer> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Typer user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("email", user.Email));
            identity.AddClaim(new Claim("login", user.Login));
            identity.AddClaim(new Claim("userName", user.UserName));
            
            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }
    }
}
