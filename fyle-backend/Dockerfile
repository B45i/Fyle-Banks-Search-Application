FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["fyle-backend/fyle-backend.csproj", "fyle-backend/"]
RUN dotnet restore "fyle-backend/fyle-backend.csproj"
COPY . .
WORKDIR "/src/fyle-backend"
RUN dotnet build "fyle-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fyle-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fyle-backend.dll"]