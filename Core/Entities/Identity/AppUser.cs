
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public partial class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}