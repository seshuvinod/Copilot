
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the csproj and restore first to leverage Docker layer caching
COPY ["Copilot.csproj", "./"]
RUN dotnet restore "Copilot.csproj"

# Copy the rest of the sources and publish
COPY . .
RUN dotnet publish "Copilot.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Ensure the DLL name matches your project output (case-sensitive on Linux)
ENTRYPOINT ["dotnet", "Copilot.dll"]		
