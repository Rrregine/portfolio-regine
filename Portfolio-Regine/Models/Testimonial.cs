using System.ComponentModel.DataAnnotations;

namespace Portfolio_Regine.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required, MaxLength(500)]
        public required string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false; // Default: Not Approved
    }

}
