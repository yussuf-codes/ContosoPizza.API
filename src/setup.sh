dotnet user-secrets --project ContosoPizza.API init

dotnet user-secrets --project ContosoPizza.API set "ConnectionStrings:DefaultConnection" "<SQL Server Connection String>"

dotnet dotnet-ef database --project ContosoPizza.API update
