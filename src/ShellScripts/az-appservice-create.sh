echo Set variables
randomnum=11170
resourcegroup=blog-$randomnum-rg
appservicename=blog-$randomnum-appsvc
webappname=blog-$randomnum-webapp
location=southcentralus
sku=FREE

echo Create resource group $resourcegroup
az group create --name $resourcegroup --location $location

echo Create appservice $appservicename
az appservice plan create --resource-group $resourcegroup --name $appservicename --location $location --sku $sku --is-linux

echo Create webapp $webappname
az webapp create --resource-group $resourcegroup --plan $appservicename --name $webappname --runtime "DOTNETCORE|3.1"
