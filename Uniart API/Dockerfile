#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Development
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UniArt.Api/UniArt.Api.csproj", "UniArt.Api/"]
COPY ["Uniart.Dto/Uniart.Dto.csproj", "Uniart.Dto/"]
COPY ["Uniart.Services/Uniart.Services.csproj", "Uniart.Services/"]
COPY ["Uniart.DataAccess/Uniart.DataAccess.csproj", "Uniart.DataAccess/"]
COPY ["Uniart.Entities/Uniart.Entities.csproj", "Uniart.Entities/"]
RUN dotnet restore "UniArt.Api/UniArt.Api.csproj"
COPY . .
WORKDIR "/src/UniArt.Api"
RUN dotnet build "UniArt.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniArt.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniArt.Api.dll"]