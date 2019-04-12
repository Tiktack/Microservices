FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["Tiktack.WebGraphQL.Api/Tiktack.WebGraphQL.Api.csproj", "Tiktack.WebGraphQL.Api/"]
RUN dotnet restore "Tiktack.WebGraphQL.Api/Tiktack.WebGraphQL.Api.csproj"
COPY . .
WORKDIR "/src/Tiktack.WebGraphQL.Api"
RUN dotnet build "Tiktack.WebGraphQL.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tiktack.WebGraphQL.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.WebGraphQL.Api.dll"]