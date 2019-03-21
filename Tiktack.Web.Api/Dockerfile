FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Tiktack.Web.Api/Tiktack.Web.Api.csproj Tiktack.Web.Api/
RUN dotnet restore Tiktack.Web.Api/Tiktack.Web.Api.csproj
COPY . .
WORKDIR /src/Tiktack.Web.Api
RUN dotnet build Tiktack.Web.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Tiktack.Web.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
HEALTHCHECK --interval=5s --timeout=10s --retries=3 CMD curl --fail http://localhost:80/healthcheck || exit 
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.Web.Api.dll"]
