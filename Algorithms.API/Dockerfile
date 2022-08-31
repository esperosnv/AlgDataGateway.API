#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Algorithms.API/Algorithms.API.csproj", "Algorithms.API/"]
RUN dotnet restore "Algorithms.API/Algorithms.API.csproj"
COPY . .
WORKDIR "/src/Algorithms.API"
RUN dotnet build "Algorithms.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Algorithms.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Algorithms.API.dll"]