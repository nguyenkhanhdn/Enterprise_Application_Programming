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
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = ConfigurationManager.AppSettings["StorageConnection"];
            BlobContainerClient container = new BlobContainerClient(connectionString, "images-backup2");
            container.CreateIfNotExists(PublicAccessType.Blob);

            //lines modified
            var blockBlob = container.GetBlobClient("pdf");
            using (var fileStream = System.IO.File.OpenRead(@"C:\Temps\Session7.pdf"))
            {
                blockBlob.Upload(fileStream);
            }
            //lines modified
            Console.WriteLine("Uploaded.");

            Console.ReadLine();
        }
    }
}
