using System;
using System.IO;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

string storageaccountName = Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME");
if (String.IsNullOrEmpty(storageaccountName)) {
    throw new ArgumentNullException("storageaccountName", "Must provide a storage account name");
}

// #### Connect to storage account and return a blob service client object
BlobServiceClient blobServiceClient = new BlobServiceClient(
    new Uri($"https://{storageaccountName}.blob.core.windows.net"),
    new DefaultAzureCredential());
//Console.WriteLine(blobServiceClient.Uri);

// #### Create a container in storage account and return a container client object
string containerName = $"demo-container-{Guid.NewGuid().ToString()}";
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

// #### Upload a blob to the container
string blobFileName = $"dummy-{Guid.NewGuid().ToString()}.txt";
BlobClient blobClient = containerClient.GetBlobClient(blobFileName);
string localFilePath = "./dummy.txt";
await blobClient.UploadAsync(localFilePath, true);