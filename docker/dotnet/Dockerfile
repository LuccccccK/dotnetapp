FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY app/*.csproj /app/
RUN dotnet restore

# copy everything else and build app
COPY app/. ./app/
WORKDIR /app/app/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/app/out ./
ENTRYPOINT ["dotnet", "app.dll"]