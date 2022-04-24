#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["apirest2/apirestcore31.csproj", "apirest2/"]
RUN dotnet restore "apirest2/apirestcore31.csproj"
COPY . .
WORKDIR "/src/apirest2"
RUN dotnet build "apirestcore31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "apirestcore31.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apirestcore31.dll"]