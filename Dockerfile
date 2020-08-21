FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://*:5000
ENV MyConfig__Id='73ce1157-c1b4-4d90-8669-2b33c86d7801'
ENV MyConfig__Location='from Dockerfile'
ENTRYPOINT ["dotnet", "AspNetCoreConfigExample.dll"]