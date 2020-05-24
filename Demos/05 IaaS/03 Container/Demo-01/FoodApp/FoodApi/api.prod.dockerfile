FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
LABEL author="Alexander Pajer"
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["*.csproj", "."]
RUN dotnet restore "FoodApi.csproj"
COPY . .
RUN dotnet build "FoodApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FoodApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FoodApi.dll"]

# Build Image
# docker build --rm -f "app.prod.dockerfile" -t foodservice .

# Run Image
# docker run -it --rm -p 5051:80 foodservice

# Browse using: 
# http://localhost:5050/api/food

# Publish Image to dockerhub
# docker tag foodservice arambazamba/foodservice
# docker push arambazamba/foodservice