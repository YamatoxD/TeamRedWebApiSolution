# Uppgift info 
https://docs.google.com/document/d/1mC03XOWfkkqzSxUAw5MHmrffO3QunRT9OulhKA1rQJQ/edit?usp=sharing

# Trello: 
https://trello.com/b/uW7SQhM9/project-aspnet-webapi

# Azure: 
https://teamredwebapifinal.azurewebsites.net/index.html

# SQL Server Management Studio (SSMS)
"Server=tcp:teamredapi.database.windows.net,1433;Initial Catalog=TeamRedApiDbFinal;Persist Security Info=False;User ID=teamredadmin;Password=AdminPassword!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

Username: teamredadmin
Password: AdminPassword!
![Image of SSMS Login](https://github.com/YamatoxD/TeamRedWebApiSolution/blob/master/Images/SSMS_Login.png)

# Hur man installerar
1. Öppna visual studio och välj Clone a repository.
2. copy paste 'https://github.com/YamatoxD/TeamRedWebApiSolution.git' i repository location.
3. "Connection" är till Azure databasen och "Connection2" är den locala databasen. Om du vill använda en local databas ändra "Connection2" -> "Connection"
Om du väljer att använda en local databas glöm inte att göra en 'Update-Database' i Package Manager Console
4. I 'DbContext/RealEstateContext.cs' så finns det 'void OnModelCreating' som innehåller test data

# Postman
https://www.postman.com/downloads/
1. Öppna postman och tryck på File / New... (eller gör en CTRL + N)
2. Gå till Templates och sök efter RealEstateProjectCollection
3. Tryck på Run in Postman.
4. Om du inte vet hur man gör en variable följ denna websidan https://learning.postman.com/docs/sending-requests/variables/
lägg till en variable som heter url och sätt initial/current value till localhost:5000 eller till azure websidan

# Postman Authenticate
För att bli autentiserad så kan man göra en 'Get token' och lägga in den Tokenen i 'Authorization' ändra typen till en 'Bearer token' och copy paste in sin token

Om du inte vill göra en Get Token så finns det en login som gör samma sak förutom att informationen ligger i body 
'{{url}}/api/account/login' detta är en POST

{
    "Username": "Test1",
    "Password": "Test123!"
}
