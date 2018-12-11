using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
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

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob});
            return cbc;
        }

        public CloudBlob GetBlob(string fileName, string containerName)
        {
            var container = CloudBlobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(fileName);
            return blob;

        }
    }
}
