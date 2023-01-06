namespace ProductFeedback.API.Models
{
    public class SuggestionForCreationDto
    {

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public SuggestionForCreationDto(string title, string category, string description) {
                Title = title;
                Category = category;
                Description = description;
        }
    }
}
