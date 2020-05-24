using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueApp {
    class Program {

        const string ConnectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=msgqueue15614;AccountKey=eIYR60micUpdJF/jsKa2P9l9amPBkfdj7Yk6kNuFZguibaMPUzMA4sjlIa4t3LyN7h4XUSS9H0QUAiMFza/hXg==";

        static async Task Main (string[] args) {

            var q = "demomsgs";
            SendArticleAsync ("{id: 1, name: 'xyz' }", q);
            string value = await ReceiveArticleAsync (q);

        }

        static async Task SendArticleAsync (string newsMessage, string q) {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse (ConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient ();

            CloudQueue queue = queueClient.GetQueueReference (q);
            bool createdQueue = await queue.CreateIfNotExistsAsync ();
            if (createdQueue) {
                Console.WriteLine ("The queue of news articles was created.");
            }

            CloudQueueMessage articleMessage = new CloudQueueMessage (newsMessage);
            await queue.AddMessageAsync (articleMessage);
        }

        static CloudQueue GetQueue (string q) {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse (ConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient ();
            return queueClient.GetQueueReference (q);
        }

        static async Task<string> ReceiveArticleAsync (string q) {
            CloudQueue queue = GetQueue (q);
            bool exists = await queue.ExistsAsync ();
            if (exists) {
                CloudQueueMessage retrievedArticle = await queue.GetMessageAsync ();
                if (retrievedArticle != null) {
                    string newsMessage = retrievedArticle.AsString;
                    Console.WriteLine ($"Msg: {newsMessage}")
                    await queue.DeleteMessageAsync (retrievedArticle);
                    return newsMessage;
                }
            }

            return "<queue empty or not created>";
        }
    }
}