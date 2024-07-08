using Elastic.Clients.Elasticsearch;
using ElasticSearch.Web.Models;

namespace ElasticSearch.Web.Repositories
{
    public class BlogRepository
    {
        private readonly ElasticsearchClient _elasticsearchClient;
        private const string indexName = "blogs";
        public BlogRepository(ElasticsearchClient elasticsearchClient)
        {
            _elasticsearchClient = elasticsearchClient;
        }

        public async Task<Blog?> SaveAsync(Blog blog)
        {
            blog.Created = DateTime.Now;
            var response = await _elasticsearchClient.IndexAsync(blog, s => s.Index(indexName));
            if (!response.IsValidResponse) return null;
            blog.Id = response.Id;
            return blog;
        }
    }
}
