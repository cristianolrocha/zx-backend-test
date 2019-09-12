FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
HEALTHCHECK CMD curl --fail http://localhost/health || exit 1
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/bot/bot.csproj src/bot/
RUN dotnet restore src/bot/bot.csproj
COPY . .
WORKDIR /src/src/bot
RUN dotnet build bot.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish bot.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "bot.dll"]