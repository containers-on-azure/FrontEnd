#FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 20006

#FROM microsoft/dotnet:2.1-sdk AS build
FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY src/FrontEnd.Web/FrontEnd.Web.csproj src/FrontEnd.Web/
COPY src/FrontEnd.Shared/FrontEnd.Shared.csproj src/FrontEnd.Shared/
RUN dotnet restore src/FrontEnd.Web/FrontEnd.Web.csproj
COPY . .
WORKDIR /src/src/FrontEnd.Web
RUN dotnet build FrontEnd.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FrontEnd.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FrontEnd.Web.dll"]
