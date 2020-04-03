# set variables
echo Set Variables....
resourcegroup=blog-$RANDOM
dnsnamelabel=blog-pg-115
container=blog-pg-115-$RANDOM
host=$dnsnamelabel.southcentralus.azurecontainer.io
efcorepath=../Blog.PostgresSQL.EF/Blog.PostgreSQL.EF.csproj
scriptpath=../Blog.PostgreSQL.EF/post-deploymentscripts/blog_entry_insert.sql

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

echo Run dotnet ef core
dotnet ef database update -p $efcorepath

echo Populate database with default values
psql -h $host -p 5432 -d blog -U postgres -f $scriptpath

