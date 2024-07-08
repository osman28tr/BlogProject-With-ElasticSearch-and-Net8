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

        public async Task<List<BlogViewModel>> SearchAsync(string searchText)
        {
            var blogList = await _blogRepository.SearchAsync(searchText);
            return blogList.Select(b=> new BlogViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Tags = String.Join(",",b.Tags),
                UserId = b.UserId,
                Created = b.Created.ToShortDateString()
            }).ToList();
        }
    }
}
