#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build-env
#WORKDIR /app
#
## Copy csproj and restore as distinct layers
##COPY Src/Gateway/TCBOS.ClientApi/*.csproj ./
##RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish Src/Gateway/TCBOS.ClientApi -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "TCBOS.ClientApi.dll"]