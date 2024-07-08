using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ElasticSearch.Web.ViewModels
{
    public class CreatedBlogViewModel
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;

        public List<string> Tags { get; set; } = new();
    }
}
