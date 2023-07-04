# Azure Blob storage Demo - Azure CLI

Create and manage Azure Blob storage using the Azure CLI

## Setup
https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-cli

``az login``
``az accout set --subscription <sub_id>``

``az group create --name rg-blob-storage-demo --location norwayeast``

## Create storage account

``az storage account create --name stblobstoragedemo001 --resource-group rg-blob-storage-demo --location norwayeast --sku Standard_ZRS --encryption-services blob``

``az storage container create --account-name stblobstoragedemo001 --name demo-container --auth-mode login``

__Heads up!__ Need to assign proper role (e.g. Storage Blob Data Contributor), regardless if owner of subscription!

``az storage blob upload --account-name stblobstoragedemo001 --container-name demo-container --name dummy.txt --file dummy.txt --auth-mode login``

## Policies
https://learn.microsoft.com/en-us/cli/azure/storage/account/management-policy?view=azure-cli-latest
https://learn.microsoft.com/en-us/azure/storage/blobs/lifecycle-management-overview

``az storage account management-policy create --account-name stblobstoragedemo001 --resource-group rg-blob-storage-demo --policy @policy.json``