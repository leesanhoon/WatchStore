FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

# Sử dụng layer caching bằng cách copy và restore project files trước
COPY ["src/WatchStore.API/WatchStore.API.csproj", "WatchStore.API/"]
COPY ["src/WatchStore.Core/WatchStore.Core.csproj", "WatchStore.Core/"]
COPY ["src/WatchStore.Infrastructure/WatchStore.Infrastructure.csproj", "WatchStore.Infrastructure/"]

# Restore packages với layer caching
RUN dotnet restore "WatchStore.API/WatchStore.API.csproj" \
    --runtime alpine-x64 \
    --use-current-runtime

# Copy source code
COPY src/ .

# Build với các tối ưu
RUN dotnet publish "WatchStore.API/WatchStore.API.csproj" \
    --no-restore \
    --configuration Release \
    --runtime alpine-x64 \
    --self-contained true \
    --output /app/publish \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true \
    /p:PublishReadyToRun=true \
    /p:EnableCompressionInSingleFile=true

# Final image nhỏ gọn
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["./WatchStore.API"]