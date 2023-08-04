FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DockSweeper.Presentation/DockSweeper.Presentation.csproj", "DockSweeper.Presentation/"]
RUN dotnet restore "DockSweeper.Presentation/DockSweeper.Presentation.csproj"
COPY . .
WORKDIR "/src/DockSweeper.Presentation"
RUN dotnet build "DockSweeper.Presentation.csproj" -c Release -o /app/build

# Trust the HTTPS development certificate
RUN dotnet dev-certs https --trust

FROM build AS publish
RUN dotnet publish "DockSweeper.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockSweeper.Presentation.dll"]
