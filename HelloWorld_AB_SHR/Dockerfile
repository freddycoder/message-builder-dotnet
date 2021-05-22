#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HelloWorld_AB_SHR/Hello_World.csproj", "HelloWorld_AB_SHR/"]
COPY ["message-builder-core/message-builder-core.csproj", "message-builder-core/"]
COPY ["message-builder-compatibility/message-builder-compatibility.csproj", "message-builder-compatibility/"]
COPY ["message-builder-util/message-builder-util.csproj", "message-builder-util/"]
COPY ["message-builder-xml/message-builder-xml.csproj", "message-builder-xml/"]
COPY ["message-builder-release-cda-ab-shr/message-builder-release-cda-ab-shr.csproj", "message-builder-release-cda-ab-shr/"]
COPY ["message-builder-release-ab_r02_04_03_shr/message-builder-release-ab_r02_04_03_shr.csproj", "message-builder-release-ab_r02_04_03_shr/"]
RUN dotnet restore "HelloWorld_AB_SHR/Hello_World.csproj"
COPY . .
WORKDIR "/src/HelloWorld_AB_SHR"
RUN dotnet build "Hello_World.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hello_World.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hello_World.dll"]