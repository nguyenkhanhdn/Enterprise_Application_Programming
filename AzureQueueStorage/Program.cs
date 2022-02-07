using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureQueueStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnection"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage("Hello, World");
            queue.AddMessage(message);

            // Peek at the next message
            CloudQueueMessage peekedMessage = queue.PeekMessage();

            // Display message.
            //Console.WriteLine(peekedMessage.AsString);

            // Get the message from the queue and update the message contents.
            //CloudQueueMessage 
            message = queue.GetMessage();
            message.SetMessageContent("Updated contents.");
            queue.UpdateMessage(message,
                TimeSpan.FromSeconds(60.0),  // Make it visible for another 60 seconds.
                MessageUpdateFields.Content | MessageUpdateFields.Visibility);
            
            message = queue.PeekMessage();
            Console.WriteLine(message.AsString);

            //Process the message in less than 30 seconds, and then delete the message
            //queue.DeleteMessage(message);


            foreach (CloudQueueMessage message2 in queue.GetMessages(20, TimeSpan.FromMinutes(5)))
            {
                // Process all messages in less than 5 minutes, deleting each message after processing.
                queue.DeleteMessage(message2);
            }

            Console.WriteLine("Removing message from queue");
            Console.ReadLine();

        }

    }
}

