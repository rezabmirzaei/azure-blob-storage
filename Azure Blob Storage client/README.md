# Azure Blob storage Demo - Client library for .NET

Create and manage Azure Blob storage containers using the client library for .NET.

## Setup

[Quickstart: Azure Blob Storage client library for .NET](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet?tabs=visual-studio%2Cmanaged-identity%2Croles-azure-cli%2Csign-in-azure-cli%2Cidentity-visual-studio)

* A storage account in your Azure subscription
* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (.NET 7.0 as of July 23)

The provided .NET console app was created and configured as such:

* ``dotnet new console``
* ``dotnet add package Azure.Storage.Blobs``
* ``dotnet add package Azure.Identity``

Create an environment variable ``STORAGE_ACCOUNT_NAME`` containing the name of the storage account to use.

## Authenticate to Azure

* ``az login``
* __Heads up!__ Must have "Storage Blob Data Contributor" role.

Run the console app with ``dotnet run``. Enjoy.