#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FlagExplorer.Testing/FlagExplorer.Testing.csproj", "FlagExplorer.Testing/"]
COPY ["FlagExplorer.Api/FlagExplorer.Api.csproj", "FlagExplorer.Api/"]
COPY ["FlagExplorer.Application/FlagExplorer.Application.csproj", "FlagExplorer.Application/"]
COPY ["FlagExplorer.Domain/FlagExplorer.Domain.csproj", "FlagExplorer.Domain/"]
COPY ["FlagExplorer.Infrastructure/FlagExplorer.Infrastructure.csproj", "FlagExplorer.Infrastructure/"]
RUN dotnet restore "./FlagExplorer.Testing/./FlagExplorer.Testing.csproj"
COPY . .
WORKDIR "/src/FlagExplorer.Testing"
RUN dotnet build "./FlagExplorer.Testing.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FlagExplorer.Testing.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlagExplorer.Testing.dll"]