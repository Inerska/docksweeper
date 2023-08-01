FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DockSweeper.Presentation/DockSweeper.Presentation.csproj", "DockSweeper.Presentation/"]
RUN dotnet restore "DockSweeper.Presentation/DockSweeper.Presentation.csproj"
COPY . .
WORKDIR "/src/DockSweeper.Presentation"
RUN dotnet build "DockSweeper.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockSweeper.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockSweeper.Presentation.dll"]
