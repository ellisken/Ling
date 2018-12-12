using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Models
{
    public class Blob
    {
        IConfiguration Configuration { get; }
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }


        public Blob(string storageAccountName, string storageAccountString, IConfiguration configuration)
        {
            Configuration = configuration;
            CloudStorageAccount = CloudStorageAccount.Parse(Configuration["CloudStorageConnection"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Gets a blob container from storage
        /// </summary>
        /// <param name="containerName">The name of the container</param>
        /// <returns>the container</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob});
            return cbc;
        }

        /// <summary>
        /// Gets a blob file from storage
        /// </summary>
        /// <param name="fileName">The file's name</param>
        /// <param name="containerName">The container's name</param>
        /// <returns>The requested blob (by name)</returns>
        public CloudBlob GetBlob(string fileName, string containerName)
        {
            var container = CloudBlobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(fileName);
            return blob;
        }
        
        /// <summary>
        /// Uploads a new file to Blob storage
        /// </summary>
        /// <param name="container">The blob container</param>
        /// <param name="fileName">File to upload's name</param>
        /// <param name="filePath">File to upload's path</param>
        public async void UploadFile(CloudBlobContainer container, string fileName, Stream filePath)
        {
            var blobfile = container.GetBlockBlobReference(fileName);
            await blobfile.UploadFromFileAsync(fileName);
        }
    }
}
