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

FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
CMD ["dotnet", "MCPDemo.MCP.dll"]