using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace ElasticSearch.Web.Extensions
{
    public static class ElasticSearchEx
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            var username = configuration.GetSection("Elastic")["Username"]!;
            var password = configuration.GetSection("Elastic")["Password"]!;
            var url = configuration.GetSection("Elastic")["Url"]!;
            var settings =
                new ElasticsearchClientSettings(new Uri(url)).Authentication(
                    new BasicAuthentication(username, password));
            var client = new ElasticsearchClient(settings);
            services.AddSingleton(client);
        }
    }
}
