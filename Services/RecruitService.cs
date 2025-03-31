using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;
using Recruits.api.Interfaces; // Provides high-level Elasticsearch client
using Recruits.api.Models;

namespace Recruits.api.Services
{
    // Implements IRecruitService, providing functionality for recruit operations
    public class RecruitService : IRecruitService
    {
        private readonly ElasticClient _client;

        // Constructor: Initializes the connection to Elasticsearch
        public RecruitService()
        {
            // Connection settings for the Elasticsearch client
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("recruits"); // Sets the default index to "recruits"
            _client = new ElasticClient(settings); // Creates the Elasticsearch client
        }

        // Searches for recruits in Elasticsearch using a query
        public async Task<IEnumerable<Recruit>> SearchRecruitsAsync(string query)
        {
            // Sends a search request to Elasticsearch
            var response = await _client.SearchAsync<Recruit>(s => s
                .Query(q => q.QueryString(d => d.Query(query)))); // Uses QueryString for flexible searches

            // Checks if the response is valid
            if (!response.IsValid)
            {
                // Throws an exception if the search fails
                throw new Exception($"Elasticsearch search error: {response.OriginalException.Message}");
            }

            // Returns the list of recruits from the response
            return response.Documents;
        }

        // Adds a new recruit to the Elasticsearch index
        public async Task AddRecruitAsync(Recruit recruit)
        {
            // Sends a request to Elasticsearch to index (store) the recruit document
            var response = await _client.IndexDocumentAsync(recruit);

            // Checks if the response is valid
            if (!response.IsValid)
            {
                // Throws an exception if the indexing fails
                throw new Exception($"Failed to add recruit: {response.OriginalException.Message}");
            }
        }

        public Task<IEnumerable<Recruit>> SeachRecruitsAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
