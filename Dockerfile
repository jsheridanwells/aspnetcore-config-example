FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS final
WORKDIR /app
EXPOSE 5000
ENV ASPNETOCRE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AspNetCoreConfigExample.csproj", "./"]
RUN dotnet restore "./AspNetCoreConfigExample.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "AspNetCoreConfigExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreConfigExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreConfigExample.dll"]

