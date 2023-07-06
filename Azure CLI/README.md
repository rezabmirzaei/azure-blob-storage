# Azure Blob storage Demo - Azure CLI

Create and manage Azure Blob storage using the Azure CLI.

## Setup

[Quickstart: Create, download, and list blobs with Azure CLI](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-cli)

* ``az login``
* ``az accout set --subscription <sub_id>``
* ``az group create --name rg-blob-storage-demo --location norwayeast``

Create an environment variable ``STORAGE_ACCOUNT_NAME`` containing the name of the storage account to use.

## Create storage account

* ``az storage account create --name <STORAGE_ACCOUNT_NAME> --resource-group rg-blob-storage-demo --location norwayeast --sku Standard_ZRS --encryption-services blob``
* ``az storage container create --account-name <STORAGE_ACCOUNT_NAME> --name demo-container --auth-mode login``

 __Heads up!__ Need to assign proper role (e.g. Storage Blob Data Contributor), regardless if owner of subscription!

## Upload a file

* ``az storage blob upload --account-name <STORAGE_ACCOUNT_NAME> --container-name demo-container --name dummy.txt --file dummy.txt --auth-mode login``

## Policies

[az storage account management-policy](https://learn.microsoft.com/en-us/cli/azure/storage/account/management-policy?view=azure-cli-latest)

``az storage account management-policy create --account-name <STORAGE_ACCOUNT_NAME> --resource-group rg-blob-storage-demo --policy policy.json``

See [Optimize costs by automatically managing the data lifecycle](https://learn.microsoft.com/en-us/azure/storage/blobs/lifecycle-management-overview) for more info.