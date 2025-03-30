using System;
using Elasticsearch.Net; // Provides low-level Elasticsearch client
using Nest;              // Provides high-level Elasticsearch client

namespace Recruits.api.Services
{
    // This service handles communication with the Elastic DB
    public class RecruitService
    {
        private readonly ElasticClient _client;

         public RecruitService()
        {
            //Define connection settings for  
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))//URL of server
            .DefaultIndex("demo"); ; // Sets the default index (like a database table in SQL)

            // Create an ElasticClient to interact with Elastic
            _client = new ElasticClient(settings);

        }

        //This method adds or updates a document (record) in Elasticsearch
        public void IndexDocument<T>(T document) where T: class
        {
            //Index (store) the document in Elasticsearch
            var response = _client.IndexDocument(document);

            //If the operation fails, throw an exception wiht details
            if(response.IsValid) {
                throw new Exception($"Failed to index document: {response.OriginalException}");
            }
        }

        
    }
}