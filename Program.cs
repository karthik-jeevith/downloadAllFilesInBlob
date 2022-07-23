using Azure.Storage.Blobs;
using System;

namespace DownloadAllBlops
{
    public class Program
    {
        static string connectionString = "Azure Storage account Connection string";
        static string containerName = "repository-group1";
         
        public static void Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var blobs = containerClient.GetBlobs();

            foreach (var blob in blobs)
            {
                Console.WriteLine(blob.Name);
                BlobClient blobClient = containerClient.GetBlobClient(blob.Name);
                blobClient.DownloadTo(@"C:\downloadedBlob\" + blob.Name);

            }
            Console.Read();
        }
    }
}
