# set variables
echo Set Variables....
resourcegroup=chwilrg-$RANDOM
dnsnamelabel=chwil-pg-115
container=chwil-pg-115-$RANDOM

# create a resource group
echo Create resource group $resourcegroup
az group create --name $resourcegroup --location southcentralus

#create container
echo Create container $container
az container create \
	--resource-group $resourcegroup \
	--os-type Linux \
	--name $container \
	--image postgres:11.5 \
	--ports 5432 \
	--ip-address Public \
	--dns-name-label $dnsnamelabel \
	--environment-variables="POSTGRES_PASSWORD=postgres"