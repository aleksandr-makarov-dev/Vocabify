FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /App

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Install dependencies for puppeteer
RUN apt-get update && \
    apt-get install -y \
        wget \
        gnupg2 \
        apt-transport-https \
        ca-certificates \
        fonts-liberation \
        libappindicator3-1 \
        libasound2 \
        libatk-bridge2.0-0 \
        libatk1.0-0 \
        libcups2 \
        libdbus-1-3 \
        libgdk-pixbuf2.0-0 \
        libnspr4 \
        libnss3 \
        libx11-xcb1 \
        libxcomposite1 \
        libxdamage1 \
        libxrandr2 \
        xdg-utils \
        libgbm1 \
        libxcb-dri3-0 \
        libxss1 && \
    rm -rf /var/lib/apt/lists/*


WORKDIR /App
COPY --from=build /App/out .
# ENTRYPOINT ["dotnet", "Vocabify.API.dll"]

# Use in heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Vocabify.API.dll