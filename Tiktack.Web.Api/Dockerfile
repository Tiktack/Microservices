FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Tiktack.Web.Api/Tiktack.Web.Api.csproj", "Tiktack.Web.Api/"]
COPY ["Tiktack.Common.Messaging/Tiktack.Common.Messaging.csproj", "Tiktack.Common.Messaging/"]
COPY ["Tiktack.Web.DataLayer/Tiktack.Web.DataLayer.csproj", "Tiktack.Web.DataLayer/"]
COPY ["Tiktack.Common.Core/Tiktack.Common.Core.csproj", "Tiktack.Common.Core/"]
COPY ["Titkack.Web.BusinessLayer/Titkack.Web.BusinessLayer.csproj", "Titkack.Web.BusinessLayer/"]
COPY ["Tiktack.Common.Kafka/Tiktack.Common.Kafka.csproj", "Tiktack.Common.Kafka/"]
RUN dotnet restore "Tiktack.Web.Api/Tiktack.Web.Api.csproj"
COPY . .
WORKDIR "/src/Tiktack.Web.Api"
RUN dotnet build "Tiktack.Web.Api.csproj" -c Release -o /app
COPY ./Tiktack.Web.ApiML.Model/MLModel.zip .

FROM build AS publish
RUN dotnet publish "Tiktack.Web.Api.csproj" -c Release -o /app
COPY ./Tiktack.Web.ApiML.Model/MLModel.zip .

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.Web.Api.dll"]