using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SSTWeb.Models
{
    public class ExternalLoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ClaimsPrincipal Principal { get; set; }
    }
}
