FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MCPDemo.MCP/MCPDemo.MCP.csproj", "MCPDemo.MCP/"]
COPY ["MCPDemo.Common/MCPDemo.Common.csproj", "MCPDemo.Common/"]
RUN dotnet restore "MCPDemo.MCP/MCPDemo.MCP.csproj"
COPY . .
WORKDIR "/src/MCPDemo.MCP"
RUN dotnet build "MCPDemo.MCP.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MCPDemo.MCP.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCPDemo.MCP.dll"]