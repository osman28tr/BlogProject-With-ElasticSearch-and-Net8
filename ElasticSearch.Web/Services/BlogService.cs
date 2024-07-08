using ElasticSearch.Web.Models;
using ElasticSearch.Web.Repositories;
using ElasticSearch.Web.ViewModels;

namespace ElasticSearch.Web.Services
{
    public class BlogService
    {
        private readonly BlogRepository _blogRepository;
        public BlogService(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> SaveAsync(CreatedBlogViewModel newBlog)
        {
            var blog = new Blog
            {
                Title = newBlog.Title,
                Content = newBlog.Content,
                Tags = newBlog.Tags.Split(","),
                UserId = Guid.NewGuid()
            };
            var isCreatedBlog = await _blogRepository.SaveAsync(blog);
            return isCreatedBlog != null;
        }
    }
}
