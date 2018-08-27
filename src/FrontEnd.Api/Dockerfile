#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base -- for now in VS tooling must use windows based image
#FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 20008

#FROM microsoft/dotnet:2.1-sdk AS build
FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY src/FrontEnd.Api/FrontEnd.Api.csproj src/FrontEnd.Api/
COPY src/FrontEnd.Shared/FrontEnd.Shared.csproj src/FrontEnd.Shared/
RUN dotnet restore src/FrontEnd.Api/FrontEnd.Api.csproj
COPY . .
WORKDIR /src/src/FrontEnd.Api
RUN dotnet build FrontEnd.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FrontEnd.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FrontEnd.Api.dll"]
