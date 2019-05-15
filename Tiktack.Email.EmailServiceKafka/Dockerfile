FROM mcr.microsoft.com/dotnet/core/runtime:3.0-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["Tiktack.Email.EmailServiceKafka/Tiktack.Email.EmailServiceKafka.csproj", "Tiktack.Email.EmailServiceKafka/"]
COPY ["Tiktack.Email.Core/Tiktack.Email.Core.csproj", "Tiktack.Email.Core/"]
COPY ["Tiktack.Common.Kafka/Tiktack.Common.Kafka.csproj", "Tiktack.Common.Kafka/"]
RUN dotnet restore "Tiktack.Email.EmailServiceKafka/Tiktack.Email.EmailServiceKafka.csproj"
COPY . .
WORKDIR "/src/Tiktack.Email.EmailServiceKafka"
RUN dotnet build "Tiktack.Email.EmailServiceKafka.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tiktack.Email.EmailServiceKafka.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.Email.EmailServiceKafka.dll"]