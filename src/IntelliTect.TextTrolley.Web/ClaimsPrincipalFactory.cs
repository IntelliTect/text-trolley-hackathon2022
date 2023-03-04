using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using IntelliTect.TextTrolley.Data.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppDbContext = IntelliTect.TextTrolley.Data.AppDbContext;

namespace IntelliTect.TextTrolley.Web;

public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
{
    private AppDbContext Db { get; }
    public ClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, AppDbContext db) : base(userManager, roleManager, options)
    {
        Db = db;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("id", user.ApplicationUserId.ToString()));
        //add claims here
      
        return identity;
    }
}
