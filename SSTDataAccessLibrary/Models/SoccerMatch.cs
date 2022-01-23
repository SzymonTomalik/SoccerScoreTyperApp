using System;
using System.ComponentModel.DataAnnotations;

namespace SSTDataAccessLibrary.Models
{
    public class SoccerMatch
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Stage { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompetitionGroup { get; set; }

        [Required]
        [MaxLength(30)]
        public string MatchResult { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string HomeTeam { get; set; }

        [Required]
        public int HomeTeamScore { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AwayTeam { get; set; }

        [Required]
        public int AwayTeamScore { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

    }
}
