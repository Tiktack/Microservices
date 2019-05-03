#build 
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build
WORKDIR /src
COPY Tiktack.gRPC.Server.csproj .
RUN dotnet restore "Tiktack.gRPC.Server.csproj"
COPY . .
RUN dotnet publish -c Release -o /build

#run
FROM  mcr.microsoft.com/dotnet/core/aspnet:3.0
COPY --from=build /build /app
WORKDIR /app
EXPOSE 9988
ENTRYPOINT ["dotnet", "Tiktack.gRPC.Server.dll"]
