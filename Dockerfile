FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Nullforce.StreamTools.Followers/Nullforce.StreamTools.Followers.csproj ./src/Nullforce.StreamTools.Followers/Nullforce.StreamTools.Followers.csproj
RUN dotnet restore ./src/Nullforce.StreamTools.Followers/Nullforce.StreamTools.Followers.csproj

# copy everything else and build the app
COPY src/ ./src
RUN dotnet publish -c Release -o /app --no-restore ./src/Nullforce.StreamTools.Followers/Nullforce.StreamTools.Followers.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Nullforce.StreamTools.Followers.dll"]
