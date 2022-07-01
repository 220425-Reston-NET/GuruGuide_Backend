from mcr.microsoft.com/dotnet/sdk:6.0 as build

workdir /app

copy *.sln ./
copy GuruGuideAPI/*.csproj GuruGuideAPI/
copy GuruGuideBL/*.csproj GuruGuideBL/
copy GuruGuideDL/*.csproj GuruGuideDL/
copy GuruGuideModels/*.csproj GuruGuideModels/

copy . ./

run dotnet build

run dotnet publish -c Release -o publish



from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app

copy --from=build /app/publish ./

cmd ["dotnet", "GuruGuideAPI.dll"]

# # copy /publish ./

# # entrypoint ["dotnet", "GuruGuideAPI.dll"]

expose 80


# # env ASPNETCORE_URLS=http://+:5000