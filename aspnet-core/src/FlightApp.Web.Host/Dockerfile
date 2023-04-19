FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/FlightApp.Web.Host/FlightApp.Web.Host.csproj", "src/FlightApp.Web.Host/"]
COPY ["src/FlightApp.Web.Core/FlightApp.Web.Core.csproj", "src/FlightApp.Web.Core/"]
COPY ["src/FlightApp.Application/FlightApp.Application.csproj", "src/FlightApp.Application/"]
COPY ["src/FlightApp.Core/FlightApp.Core.csproj", "src/FlightApp.Core/"]
COPY ["src/FlightApp.EntityFrameworkCore/FlightApp.EntityFrameworkCore.csproj", "src/FlightApp.EntityFrameworkCore/"]
WORKDIR "/src/src/FlightApp.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/FlightApp.Web.Host", "src/FlightApp.Web.Host"]
COPY ["src/FlightApp.Web.Core", "src/FlightApp.Web.Core"]
COPY ["src/FlightApp.Application", "src/FlightApp.Application"]
COPY ["src/FlightApp.Core", "src/FlightApp.Core"]
COPY ["src/FlightApp.EntityFrameworkCore", "src/FlightApp.EntityFrameworkCore"]
WORKDIR "/src/src/FlightApp.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "FlightApp.Web.Host.dll"]
