# Build da Aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Backend/To-do_list_api/To-do_list_api.csproj ./Backend/To-do_list_api/

RUN dotnet restore "Backend/To-do_list_api/To-do_list_api.csproj"

COPY . .

RUN dotnet publish "Backend/To-do_list_api/To-do_list_api.csproj" -c Release -o /app/publish

# Runtime da Aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "To-do_list_api.dll"]
