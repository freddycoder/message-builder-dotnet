#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelloWorld/Hello_World.csproj", "HelloWorld/"]
RUN dotnet restore "HelloWorld/Hello_World.csproj"
COPY . .
WORKDIR "/src/HelloWorld"
RUN dotnet build "Hello_World.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hello_World.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hello_World.dll"]