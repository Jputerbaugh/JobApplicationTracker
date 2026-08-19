FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["JobApplicationTracker.csproj", "./"]
RUN dotnet restore "JobApplicationTracker.csproj"

COPY . .
RUN dotnet publish "JobApplicationTracker.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
ENV DOTNET_HOSTBUILDER_RELOADCONFIGONCHANGE=false
EXPOSE 10000

ENTRYPOINT ["dotnet", "JobApplicationTracker.dll"]