using System;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class ScoreType
    {

        public int Id { get; set; }

        [Required]
        public int TypedHomeTeamResult { get; set; }
        
        [Required]
        public int TypedAwayTeamResult { get; set; }
        
        [Required]
        public int Points { get; set; } = 0;
        
        [Required]
        public TyperGroupAccount TyperGroupAccount { get; set; }
        
        [Required]
        public SoccerMatch SoccerMatch { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [Required]
        public DateTime ChangedDate { get; set; } = DateTime.Now;
    }
}