FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Tiktack.WebGraphQL.Api/Tiktack.WebGraphQL.Api.csproj", "Tiktack.WebGraphQL.Api/"]
COPY ["Tiktack.WebGraphQL.BusinessLayer/Tiktack.WebGraphQL.BusinessLayer.csproj", "Tiktack.WebGraphQL.BusinessLayer/"]
COPY ["Tiktack.WebGraphQL.DataLayer/Tiktack.WebGraphQL.DataLayer.csproj", "Tiktack.WebGraphQL.DataLayer/"]
COPY ["Tiktack.Common.DataAccess/Tiktack.Common.DataAccess.csproj", "Tiktack.Common.DataAccess/"]
COPY ["Tiktack.Common.Core/Tiktack.Common.Core.csproj", "Tiktack.Common.Core/"]
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