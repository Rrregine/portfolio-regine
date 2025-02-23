namespace Portfolio_Regine.Models
{
    public class HomeViewModel
    {
        public required List<Testimonial> Testimonials { get; set; }
        public required List<Project> Projects { get; set; }
        public required Dictionary<string, string> TranslatedStrings { get; set; }
    }

}
