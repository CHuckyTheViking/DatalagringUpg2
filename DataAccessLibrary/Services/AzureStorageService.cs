using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace DataAccessLibrary.Services
{
    public class AzureStorageService
    {
        public static string connectionString = "DefaultEndpointsProtocol=https;AccountName=jm23sa;AccountKey=TCeFeu3/n8QMNkEhiSWtm1Pj7fvWZQ3FEPHCcYKGe5tvLBNiC8wEP4VlfzMZr8sy2MIMknmFKTs8DTUTpqbJPQ==;EndpointSuffix=core.windows.net";
        public static byte[] picture { get; set; }
        public static async Task<string> UploadPictureAsync(StorageFile picture)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("issuepictures");

                await container.CreateIfNotExistsAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference(picture.Name);
                
                await blob.UploadFromFileAsync(picture);              
            }
            catch { }

            return picture.Name;
        }

        public static async Task<byte[]> GetPictureAsync(string pictureName)
        {

            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("issuepictures");
                CloudBlockBlob blob = container.GetBlockBlobReference($"{pictureName}");

                await blob.FetchAttributesAsync();
                long fileByteLength = blob.Properties.Length;
                picture = new byte[fileByteLength];

                await blob.DownloadToByteArrayAsync(picture, 0);
            }
            catch { }

            return picture;

        }


    }
}
