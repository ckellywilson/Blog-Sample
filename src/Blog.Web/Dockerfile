FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Blog.Web/Blog.Web.csproj", "src/Blog.Web/"]
RUN dotnet restore "src/Blog.Web/Blog.Web.csproj"
COPY . .
WORKDIR "/src/src/Blog.Web"
RUN dotnet build "Blog.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.Web.dll"]
