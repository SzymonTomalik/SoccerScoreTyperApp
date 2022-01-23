
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class TyperGroup
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public List<TyperGroupAccount> TyperGroupAccountsList { get; set; }


    }
}