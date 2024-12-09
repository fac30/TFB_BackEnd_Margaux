# Use the official .NET image as a base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TFB_BackEnd_Margaux.csproj", "./"]
RUN dotnet restore "TFB_BackEnd_Margaux.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TFB_BackEnd_Margaux.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "TFB_BackEnd_Margaux.csproj" -c Release -o /app/publish

# Copy the build into the base image and define the entry point
FROM base AS final
WORKDIR /app

# Copy the published app into the container
COPY --from=publish /app/publish .

# Copy the .env file into the container (important for accessing environment variables)
COPY .env .env

ENTRYPOINT ["dotnet", "TFB_BackEnd_Margaux.dll"]
