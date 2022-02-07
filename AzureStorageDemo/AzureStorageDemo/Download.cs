using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageDemo
{
    class Download
    {
        static void Main() 
        {
            string connectionString = ConfigurationManager.AppSettings["StorageConnection"];
            BlobContainerClient container = new BlobContainerClient(connectionString, "images-backup");
            container.CreateIfNotExists(PublicAccessType.Blob);

            //lines modified
            var blockBlob = container.GetBlobClient("mikepic.png");
            using (var fileStream = System.IO.File.OpenWrite(@"C:\temps\backup.jpg"))
            {
                blockBlob.DownloadTo(fileStream);
            }
            //lines modified
            Console.WriteLine("Downloaded.");
            Console.ReadLine();
        }
    }
}
