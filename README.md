# OrdersSampleProject

This code represents a simple proof-of-concept API made with .NET 6, ASP.NET, and EF Core. 
Other used technologies worth mentioning: Linq, AutoMapper, SQLite.

## Architecture
The project architecture is a basic service-repository pattern:

<img width="683" alt="Screenshot 2022-11-08 at 19 56 20" src="https://user-images.githubusercontent.com/11898337/200651438-2635364e-317a-4ad3-9b43-dddb63226a2a.png">

Repository layer accessess the database and implements CRUD, business service layer contains business logic, and controllers translate the API outputs and inputs (using DTOs).    

## TO-DOs
Project could be extended by implementing:
 - more business logic in services
 - better input validation in services
 - more complex db structure
 - paged results
 - UnitOfWork pattern
 - authentication (e.g. AAD)

