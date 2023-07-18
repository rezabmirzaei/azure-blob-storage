using System;
using System.IO;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;


// #### Requirement: A storages account, with it's name stored in env. var "STORAGE_ACCOUNT_NAME"

string storageaccountName = Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME");
if (String.IsNullOrEmpty(storageaccountName))
{
    throw new ArgumentNullException("storageaccountName", "Must provide a storage account name");
}

// #### Connect to storage account and return a blob service client object
// Never add username/pwd, tokens, key sor any other secrets to your code!
// string connectionString = "[Access keys] > [Connection string]";
// BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
BlobServiceClient blobServiceClient = new BlobServiceClient(
    new Uri($"https://{storageaccountName}.blob.core.windows.net"),
    new DefaultAzureCredential());
Console.WriteLine($"\nConnected to storage account {blobServiceClient.Uri}");


// #### Create a container in storage account and return a container client object
Console.Write("#### Press any key to add container to storage account");
Console.ReadLine();
string containerName = $"demo-container-{Guid.NewGuid().ToString()}";
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);


// #### Upload a blob to the container
Console.Write("\n#### Press any key to add blob to container");
Console.ReadLine();
string blobFileName = $"dummy-{Guid.NewGuid().ToString()}.txt";
BlobClient blobClient = containerClient.GetBlobClient(blobFileName);
string localFilePath = "./dummy.txt";
await blobClient.UploadAsync(localFilePath, true);


// #### List blobs in the container
Console.Write("\n#### Press any key to list blobs in container");
Console.ReadLine();
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine($"\t{blobItem.Name}");
}


// #### Clean up (delete it all)
Console.Write("\n#### Press any key to delete everything");
Console.ReadLine();
Console.WriteLine("Deleting blob container...");
await containerClient.DeleteAsync();