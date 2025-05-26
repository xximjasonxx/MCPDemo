FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MCPDemo.Api/MCPDemo.Api.csproj", "MCPDemo.Api/"]
COPY ["MCPDemo.Data/MCPDemo.Data.csproj", "MCPDemo.Data/"]
COPY ["MCPDemo.Common/MCPDemo.Common.csproj", "MCPDemo.Common/"]
RUN dotnet restore "MCPDemo.Api/MCPDemo.Api.csproj"
COPY . .
WORKDIR "/src/MCPDemo.Api"
RUN dotnet build "MCPDemo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MCPDemo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCPDemo.Api.dll"]
