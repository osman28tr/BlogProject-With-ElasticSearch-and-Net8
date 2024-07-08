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

        public async Task<List<Blog>> SearchAsync(string searchText)
        {
            //title and content search
            var searchResponse = await _elasticsearchClient.SearchAsync<Blog>(s => s
                .Index(indexName)
                .Size(1000)
                .Query(q => q
                    .Bool(b =>
                        b.Should(
                            s => s.Match(m => m.Field(f => f.Content)
                                .Query(searchText)), //or
                            s => s.MatchBoolPrefix(p => p.Field(f => f.Title)
                                .Query(searchText))
                        ))
                )
            );
            foreach (var hit in searchResponse.Hits) hit.Source.Id = hit.Id;
            return searchResponse.Documents.ToList();
        }
    }
}
