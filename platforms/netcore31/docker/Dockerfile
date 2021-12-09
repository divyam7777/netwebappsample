FROM mcr.microsoft.com/dotnet/aspnet:3.1.21-alpine3.14 AS base

EXPOSE 80

ENV ASPNETCORE_URLS=http://*:80

WORKDIR /app
COPY /app .

ENTRYPOINT ["dotnet", "NetWebAppSample.dll"]