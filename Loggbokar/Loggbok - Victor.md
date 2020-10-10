# Loggbok - Victor

# Vecka 37
Vi började detta projekt genom att diskutera hur vi skulle bygga upp den.
Vi bestämde att det skulle skrivas i .NET core 3.1 

Sedan gjorde vi en diagram på hur databasen skulle se ut. Vi försökte göra databasen så RESTful som vi kunde.
Vi fick lite problem med hur vi skulle sätta upp databasen.

Sedan satt vi och bestämde vilken som skulle göra vad och när det var klart så studerade vi på det som vi valde.

Vi gjorde diagrammet i Draw.io
![Image of diagram](https://github.com/YamatoxD/TeamRedWebApiSolution/blob/master/Images/Diagram.PNG)

Databasen var skriven i Code-first med hjälp av EntityFramework. 
Vi fick inte så himla mycket problem just nu när vi först gjorde databasen.

# Vecka 38
Vi la upp projektet på Github.

Vi implementerade DTOs och controllers, sedan la vi in lite testdata som vi hade lite problem med i början att få det att fungera men det fixade vi. 
Vi fick också lite problem med foreign keys för Comments vilket tog lite tid att fixa med det blev fixat i slut, vi glömde att lägga till en reference till kommentarerna i User klassen.

Jag använde mig mest av Pluralsight för att plugga på Authentisering.

# Vecka 39
Pluggade på pluralsight mest om Identity och tittade också på Tim Corey om hur man implementerar det.

# Vecka 40
Vi gjorde en AccountController så man kunde registrera sig och få en token från Authentisering vi hade just implementerat.
Pluggade på om hur man lägger upp sitt projekt på Azure.

# Vecka 41
Swagger blev implementerat.
![Image of swagger](https://github.com/YamatoxD/TeamRedWebApiSolution/blob/master/Images/Swagger%20Screenshot.png)

Swagger gjorde det väldigt enkelt att executa kommands från hemsidan istället för att använda postman.

Det var nu jag försökte lägga upp projektet på azure och jag fick ganska många problem med det.
Det första problemet var att jag inte komm ihåg min skolemail lösen så jag fick använda Jespers istället, Vilket gick ganska bra.

Sedan så följde jag Tim Coreys video om hur man skulle publisha det till Azure.
https://youtu.be/DUfPaY6FRII?list=PLLWMQd6PeGY0bEMxObA6dtYXuJOGfxSPx

Efter jag la upp det på azure så fick jag ett Http Error 500, vilket inte sa så himla mycket om vad som var fel.

Vi testade att göra om det och publishade det till en annan Web App på Azure, Vi kunde få igång Swagger men när vi försökte regriserera en User så fick vi en 500 Error.
När jag diagnoserade det så fick jag reda på att det var en xml fil som fattades jag vet inte varför den inte var med, men jag la till den manuelt vilket fixade problemet men det skapade ett annat problem som jag inte kunde fixa.

Vi försökte en gång till att göra en ny Web App på Azure och publisha till den, detta skapade samma problem som var att xml filen fattades, jag fixade det och försökte diagnosera vad mer som var fel och då såg jag att det var ett nytt error (405 Error). Vilket sa att det inte kunde gå att logga in på databasen.
På något sätt så hade ConnectionStringen blivit corrupt och den tog inte med hela stringen, stringen gick av där lösenordet startade och satte lösen till något sånt här 
"<xml?="

Den ska se ut så här.
"Server=tcp:teamredapi.database.windows.net,1433;Initial Catalog=TeamRedApiDbFinal;Persist Security Info=False;User ID=teamredadmin;Password=AdminPassword!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

men den såg ut så här.
"Server=tcp:teamredapi.database.windows.net,1433;Initial Catalog=TeamRedApiDbFinal;Persist Security Info=False;User ID=teamredadmin;Password=<xml?="

För att fixa det problemet ändrade jag lösen på adminen och fixade connectionstringen. sedan efter detta så funkerade azure websidan.
Problemet var säkert den xml filen som inte kom med när projektet publishades och att lägga till den manuelt skapade lite problem.
