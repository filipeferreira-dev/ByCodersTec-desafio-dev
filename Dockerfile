FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Challenge.Presentation.Api/Challenge.Presentation.Api.csproj", "Challenge.Presentation.Api/"]
RUN dotnet restore "Challenge.Presentation.Api/Challenge.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/Challenge.Presentation.Api"
RUN dotnet build "Challenge.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challenge.Presentation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.Presentation.Api.dll"]