using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace CosmosReader {
    class Program {
        static void Main (string[] args) {

            var builder = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true);
            IConfigurationRoot configuration = builder.Build ();
            var conStr = configuration["ConnectionStrings"];

            CosmosClient cosmosClient;
            Database database;
            Container container;

            cosmosClient = new CosmosClient (conStr);
            database = cosmosClient.GetDatabase ("productsdb");
            container = database.GetContainer ("Products");

            var sqlQueryText = "SELECT * FROM c WHERE c.Color = 'Red'";
            QueryDefinition queryDefinition = new QueryDefinition (sqlQueryText);
            FeedIterator<Product> queryResultSetIterator = container.GetItemQueryIterator<Product> (queryDefinition);

            List<Product> redProducts = new List<Product> ();

            while (queryResultSetIterator.HasMoreResults) {
                FeedResponse<Product> currentResultSet = queryResultSetIterator.ReadNextAsync ().Result;
                foreach (Product product in currentResultSet) {
                    redProducts.Add (product);
                    Console.WriteLine ("\tRead {0}\n", product.ProductNumber);
                }
            }

        }
    }
}