FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app 
EXPOSE 443

COPY *.sln .
COPY Location.Microservice/*.csproj ./Location.Microservice/
COPY Location.Services.Contracts/*.csproj ./Location.Services.Contracts/
COPY Location.Services.Business/*.csproj ./Location.Services.Business/
COPY Location.Data.Access/*.csproj ./Location.Data.Access/
COPY Location.Data.Contracts/*.csproj ./Location.Data.Contracts/
COPY Location.Data.Object/*.csproj ./Location.Data.Object/

RUN dotnet restore ./Location.Microservice/Location.Microservice.csproj

COPY Location.Microservice/. ./Location.Microservice/
COPY Location.Services.Contracts/. ./Location.Services.Contracts/
COPY Location.Services.Business/. ./Location.Services.Business/
COPY Location.Data.Access/. ./Location.Data.Access/
COPY Location.Data.Contracts/. ./Location.Data.Contracts/
COPY Location.Data.Object/. ./Location.Data.Object/

COPY localhost.pfx /certificate/

WORKDIR /app/Location.Microservice
RUN dotnet build ./Location.Microservice.csproj -c Release -o /app/build

FROM build AS publish
WORKDIR /app/Location.Microservice
RUN dotnet publish ./Location.Microservice.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app 

COPY --from=publish /certificate/localhost.pfx /app/certificate/
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Location.Microservice.dll"]