# Challenge La Nacion Contacts.API
Web Api Rest to handle Contacts, implements the template [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) of [Jason Taylor](https://github.com/jasontaylordev).


## Stack & Technologies
* ASP.NET Core Web API 6
* Entity Framework Core 6
* MediatR
* FluentValidation
* AutoMapper
* PostgreSQL
* XUnit, Shouldly, Moq, EF Core InMemory


## Challenge Scope
Develop a RESTful API that would allow a web or mobile front-end to:
* Create a contact record
* Retrieve a contact record
* Update a contact record
* Delete a contact record
* Search for a record by email or phone number
* Retrieve all records from the same state or city
The contact record should represent the following information: name, company, profile
image, email, birthdate, phone number (work, personal) and address.

*  Use al least one design pattern.
*  Apply solid principles
*  Also please provide a unit test for at least one of the endpoints you create.


## Instructions
### Settings
* **PostgreSQLConnection**: Write the connection string to your PostgreSQL database.
> src/Presentation/LaNacion.Contacts.API: appsettings.json_
```json
"ConnectionStrings": {
  "DefaultConnection": ""
}
```


### Migration & Execution
* Execute commands in the package manager console:
  * `update-database`
* Run Project from **LaNacion.Contacts.API**