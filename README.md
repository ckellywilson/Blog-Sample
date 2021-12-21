# BlogPost
This repository can be used to build the sample project to use in training, such as with Azure DevOps certifications.

_Prep your enviornment_
* Install latest version of [.NET Core](https://dotnet.microsoft.com/download)
* Install [PowerShell Core](https://github.com/powershell/powershell)
* Open PowerShell Core
  * Check .NET Core version by running the following command: `dotnet --version`
  * Ensure Entity Framework Core is installed by running the following command: `dotnet ef`

_Set-up PostgreSQL on Docker_
This code sample uses PostgreSQL as the backend database. The easiest way to run the sample database is via a [Docker](https://docker.io)
* Install [Docker Community Edition](https://docs.docker.com/install/) and ensure the docker engine is running by running the following command: docker run hello-world
* Install [PgAdmin](https://www.pgadmin.org/download/) which will install the psql command-line tools which you can use later
* Execute the following shell script in the repository to create the docker container: `src/ShellScripts/blog-pg-container-initialize.sh`. If on Windows, then copy the contents of the file and execute.
* To see the running container, execute the following command: `docker ps`
* **Note the IP of the machine where the container is running so you can use this information to connect to the PostgreSQL instance on Port 5433**

_Create Database_
* Clone this repository
* Once the environment is cloned, In PowerShell Core navigate to the _Blog/src/Blog.PostgresSQL.EF_ directory
* Open the appSettings.config file
* In the line `"blog": "host=<your server>;port=<your port>database=blog;username=postgres;password=postgres"`
   * Change the _host_ entry to point to the IP where the PostgreSQL DB is running
   * Change the _port_ entry to "5433" (this is the port set by the docker command above)
* In PowerShell Core, stay in the _Blog/src/Blog.PostgreSQL.EF_ directory and execute the command: dotnet ef database update. This command will create the database _blog_ in PostreSQL database
* In PowerShell Core
  * Navigate to the _Blog/src/Blog.PostgreSQL/post-deploymentscripts_ directory
  * Execue the following _psql_ command `psql -h <your host> -p 5433 -d blog -f blog_entry_insert.sql`
  * Sample rows are entered in the _blog_entry_ and _blog_post_ tables

_Test Api_
* In PowerShell Core, navigate to the _Blog/src/Blog.Web_ directory
* Open in Visual Studio Code by entering the command: `code .`
* Once open in code, open the _Blog/src/Blog.Web/appSettings.json_ file and set the _host_ and _port_ settings to the values you set above in the _Blog/src/Blog.PostgreSQL.EF/appSettings.json_ file
* Debug the _Blog.Web_ project and enter the following Url in the browser 
  * Enter _http://localhost:5000/api/blog_ to see the list of _blog_entry_ values
  * Enter _http://localhost:5000/api/blog/1_ to see the _blog_entry_ value of 1.

# Updates
_2020-11-26_
* Change project references from `netcoreapp3.1` to `net6.0`, as per [Migrate from ASP.NET Core 3.1 to 5.0](https://docs.microsoft.com/en-us/aspnet/core/migration/31-to-50?view=aspnetcore-5.0&tabs=visual-studio)
