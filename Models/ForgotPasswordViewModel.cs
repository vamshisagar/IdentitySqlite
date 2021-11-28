using System.ComponentModel.DataAnnotations;

namespace IdentityExample.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}