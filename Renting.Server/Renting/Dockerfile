FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Renting.csproj", "Renting/"]
RUN dotnet restore "Renting/Renting.csproj"

WORKDIR "/src/Renting"
COPY . .

RUN dotnet build "Renting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Renting.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Renting.dll"]