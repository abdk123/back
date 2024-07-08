FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/Souccar.Web.Host/Souccar.Web.Host.csproj", "src/Souccar.Web.Host/"]
COPY ["src/Souccar.Web.Core/Souccar.Web.Core.csproj", "src/Souccar.Web.Core/"]
COPY ["src/Souccar.Application/Souccar.Application.csproj", "src/Souccar.Application/"]
COPY ["src/Souccar.Core/Souccar.Core.csproj", "src/Souccar.Core/"]
COPY ["src/Souccar.EntityFrameworkCore/Souccar.EntityFrameworkCore.csproj", "src/Souccar.EntityFrameworkCore/"]
WORKDIR "/src/src/Souccar.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Souccar.Web.Host", "src/Souccar.Web.Host"]
COPY ["src/Souccar.Web.Core", "src/Souccar.Web.Core"]
COPY ["src/Souccar.Application", "src/Souccar.Application"]
COPY ["src/Souccar.Core", "src/Souccar.Core"]
COPY ["src/Souccar.EntityFrameworkCore", "src/Souccar.EntityFrameworkCore"]
WORKDIR "/src/src/Souccar.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Souccar.Web.Host.dll"]
