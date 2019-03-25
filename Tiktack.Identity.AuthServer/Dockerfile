FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Tiktack.Identity.AuthServer/Tiktack.Identity.AuthServer.csproj", "Tiktack.Identity.AuthServer/"]
RUN dotnet restore "Tiktack.Identity.AuthServer/Tiktack.Identity.AuthServer.csproj"
COPY . .
WORKDIR "/src/Tiktack.Identity.AuthServer"
RUN dotnet build "Tiktack.Identity.AuthServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tiktack.Identity.AuthServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tiktack.Identity.AuthServer.dll"]