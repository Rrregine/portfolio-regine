# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore project files
COPY Portfolio-Regine.csproj ./Portfolio-Regine.csproj
RUN dotnet restore "./Portfolio-Regine.csproj"

# Copy the entire project and build
COPY . ./
RUN dotnet publish "./Portfolio-Regine.csproj" -c Release -o /app/out /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 8080 and 8081 as per your request
EXPOSE 8080
EXPOSE 8081

# Set the entry point for the container
ENTRYPOINT ["dotnet", "Portfolio-Regine.dll"]
