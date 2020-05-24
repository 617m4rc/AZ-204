using System;
using System.Collections.Generic;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json;

namespace EventGridPublisher {
    class ContosoItemReceivedEventData {
        [JsonProperty (PropertyName = "itemSku")]
        public string ItemSku { get; set; }
    }

    class Program {
        static void Main (string[] args) {

            var topic = "foodorder";
            var region = "westeurope";

            // TODO: Enter value for <topic-key>. You can find this in the "Access Keys" section in the
            string topicKey = "rzfzsgx249aBOJi7oUVQD8bAsoNE90f/FiuvhZNW+ZM=";
            string topicEndpoint = $"https://{topic}.{region}-1.eventgrid.azure.net/api/events";

            string topicHostname = new Uri (topicEndpoint).Host;
            TopicCredentials topicCredentials = new TopicCredentials (topicKey);
            EventGridClient client = new EventGridClient (topicCredentials);

            client.PublishEventsAsync (topicHostname, GetEventsList ()).GetAwaiter ().GetResult ();
            Console.Write ("Published events to Event Grid topic.");
        }

        static IList<EventGridEvent> GetEventsList () {
            List<EventGridEvent> eventsList = new List<EventGridEvent> ();

            for (int i = 0; i < 2; i++) {
                eventsList.Add (new EventGridEvent () {
                    Id = Guid.NewGuid ().ToString (),
                        EventType = "Contoso.Items.ItemReceived",
                        Data = new ContosoItemReceivedEventData () {
                            ItemSku = "Contoso Item SKU #1"
                        },
                        EventTime = DateTime.Now,
                        Subject = "Door1",
                        DataVersion = "2.0"
                });
            }

            return eventsList;
        }
    }
}