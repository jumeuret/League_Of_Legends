#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API_lol/API_lol.csproj", "API_lol/"]
COPY ["Tests/ConsoleTests/ConsoleTests.csproj", "Tests/ConsoleTests/"]
COPY ["StubLib/StubLib.csproj", "StubLib/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["DTO/DTO.csproj", "DTO/"]
COPY ["Entity Framework/Entity Framework.csproj", "Entity Framework/"]
RUN dotnet restore "API_lol/API_lol.csproj"
COPY . .
WORKDIR "/src/API_lol"
RUN dotnet build "API_lol.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_lol.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_lol.dll"]