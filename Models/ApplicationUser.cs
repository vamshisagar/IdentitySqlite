using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        
        
    }
}