FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Tiktack.Email.EmailService/Tiktack.Email.EmailService.csproj", "Tiktack.Email.EmailService/"]
COPY ["Tiktack.Common.Messaging/Tiktack.Common.Messaging.csproj", "Tiktack.Common.Messaging/"]
COPY ["Tiktack.Email.Core/Tiktack.Email.Core.csproj", "Tiktack.Email.Core/"]
RUN dotnet restore "Tiktack.Email.EmailService/Tiktack.Email.EmailService.csproj"
COPY . .
WORKDIR "/src/Tiktack.Email.EmailService"
RUN dotnet build "Tiktack.Email.EmailService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tiktack.Email.EmailService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.Email.EmailService.dll"]