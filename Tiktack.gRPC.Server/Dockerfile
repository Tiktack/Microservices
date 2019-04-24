FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app
WORKDIR /app
EXPOSE 9988
ENTRYPOINT ["dotnet", "Tiktack.gRPC.Server.dll"]

