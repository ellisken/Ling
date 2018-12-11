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
        }
    }
}
