using Microsoft.AspNetCore.Identity;

namespace Budy.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role(string roleName) : base(roleName)
        {
        }
    }
}