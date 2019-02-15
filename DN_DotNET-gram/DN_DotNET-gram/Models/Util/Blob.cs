using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models.Util
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        /// <summary>
        /// Creates a blob connection and blob client using user secrets.
        /// </summary>
        /// <param name="configuration"></param>
        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Creates a new container if it doesnt already exists and sets access permission.
        /// </summary>
        /// <param name="containerName"></param>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        /// <summary>
        /// Retreives a blob from a container.
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="containerName"></param>
        /// <returns>CloudBlob</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }
    }
}
