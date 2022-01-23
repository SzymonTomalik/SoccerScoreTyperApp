
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class Typer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Login { get; set; }
        [Required]
        [MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public List<TyperGroupAccount> UserGroupAccount { get; set; }
    }
}