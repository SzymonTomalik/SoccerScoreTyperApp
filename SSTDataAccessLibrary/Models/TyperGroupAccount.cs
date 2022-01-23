
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class TyperGroupAccount
    {

        public int Id { get; set; }
        [Required]
        public Typer Typer { get; set; }

        [Required]
        public TyperGroup TyperGroup { get; set; }

        [Required]
        public int Points { get; set; } = 0;
        public List<ScoreType> ScoreTypes { get; set; }





    }
}