FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
HEALTHCHECK CMD curl --fail http://localhost/health || exit 1
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/pdv/pdv.csproj src/pdv/
RUN dotnet restore src/pdv/pdv.csproj
COPY . .
WORKDIR /src/src/pdv
RUN dotnet build pdv.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish pdv.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "pdv.dll"]