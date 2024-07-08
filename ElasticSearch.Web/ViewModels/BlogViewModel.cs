using System.Text.Json.Serialization;

namespace ElasticSearch.Web.ViewModels
{
    public class BlogViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Tags { get; set; } = null!;
        public Guid UserId { get; set; }
        public string Created { get; set; }
    }
}
