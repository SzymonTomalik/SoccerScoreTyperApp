
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class Typer : IdentityUser
    {
        [Required]
        [MaxLength(40)]
        public string Login { get; set; }

        public List<TyperGroupAccount> UserGroupAccount { get; set; }
    }
}