FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore \"FilmHarbor.WebAPI/FilmHarbor.WebAPI.csproj\"
RUN dotnet publish \"FilmHarbor.WebAPI/FilmHarbor.WebAPI.csproj\" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FilmHarbor.WebAPI.dll"]