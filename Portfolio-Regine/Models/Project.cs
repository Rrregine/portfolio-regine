using System.ComponentModel.DataAnnotations;

namespace Portfolio_Regine.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public required string Description { get; set; }
        
        [Required]
        public required string DescriptionFrench { get; set; }
        
        [Required]
        public required string Skills { get; set; }

        [Required]
        public required string ImagePath { get; set; }
        
        [Required]
        public required string GitHubLink { get; set; }
    }


}
