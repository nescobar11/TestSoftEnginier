# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/TeamTask.Domain/ TeamTask.Domain/
COPY src/TeamTask.Application/ TeamTask.Application/
COPY src/TeamTask.Infrastructure/ TeamTask.Infrastructure/
COPY src/TeamTask.Api/ TeamTask.Api/
WORKDIR /src/TeamTask.Api
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "TeamTask.Api.dll"]
