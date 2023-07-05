using System;
using System.IO;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

var storageaccountName = Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME");

BlobServiceClient blobServiceClient = new BlobServiceClient(
    new Uri($"https://{storageaccountName}.blob.core.windows.net"),
    new DefaultAzureCredential());
//Console.WriteLine(blobServiceClient.Uri);
