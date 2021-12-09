FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-alpine3.14 AS base

EXPOSE 80

ENV ASPNETCORE_URLS=http://*:80

WORKDIR /app
COPY /app .

ENTRYPOINT ["dotnet", "NetWebAppSample.dll"]