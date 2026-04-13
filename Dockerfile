
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /app

COPY *.slnx ./

COPY API/API.csproj ./API/
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/

RUN dotnet restore
COPY . ./

WORKDIR /app/API
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /out .

EXPOSE 80

ENTRYPOINT ["dotnet", "API.dll"]