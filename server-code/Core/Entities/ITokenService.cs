

using Core.Entities.Identity;

namespace Core.Entities
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        
    }
}