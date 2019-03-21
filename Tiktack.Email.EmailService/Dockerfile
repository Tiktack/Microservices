FROM microsoft/dotnet:2.2-runtime-stretch-slim AS base
WORKDIR /app


FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Tiktack.Email.EmailService/Tiktack.Email.EmailService.csproj", "Tiktack.Email.EmailService/"]
COPY ["Tiktack.Common.Messaging/Tiktack.Common.Messaging.csproj", "Tiktack.Common.Messaging/"]
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