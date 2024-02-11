

using System.Security.Claims;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static  async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input,ClaimsPrincipal user)
        {
            //  var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            // return await input.Users.Include(x => x.MyAddress).SingleOrDefaultAsync(x => x.Email == email);
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.MyAddress)
                    .SingleOrDefaultAsync(x => x.Email == email);

        }
        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input,ClaimsPrincipal user)
        {
        //    var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            // return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
            return await input.Users
            .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
        }
        
    }
}