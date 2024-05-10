FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /App

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /App
COPY --from=build /App/out .

ENTRYPOINT ["dotnet", "Vocabify.API.dll"]

# Use in heroku
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet Vocabify.API.dll