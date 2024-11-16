# Game Store API

## Starting SQL Server
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest

##El comando que funcionó
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$sa_password" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

```
##Setting the connection string to secret manager

```powershell
$sa_password = "[sa password here]"
dotnet user-secrets set "ConnectionStrings:ExpiredFoodContext" "Server=localhost; Database=ExpiredFood; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```