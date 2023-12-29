# CRUD Code Test Repository

## Project Overview

In this repository, I have developed a CRUD (Create, Read, Update, Delete) application using ASP.NET, focused on managing customer information. The project adheres to a set of best practices and design patterns outlined in the requirements.

### Project Structure and Architecture

The project structure has been carefully designed with a focus on clean architecture principles. This ensures modularity, maintainability, and separation of concerns. The clean architecture pattern, as advocated by [Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture), is followed to enhance code organization and scalability.

### Model Definition

The application implements a straightforward customer model:

```csharp
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and Patterns Adherence:

- [TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022)
- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [Clean Code](https://en.wikipedia.org/wiki/SonarQube)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern with a touch of ([Event sourcing](https://en.wikipedia.org/wiki/Domain-driven_design#Event_sourcing)).

The git commit history is meticulously maintained, providing a clear and concise progression of the development work.

### Validation Implementation

The application enforces the following validations:

- During the creation process, the phone number is validated to be a valid mobile number only, leveraging the capabilities of [Google LibPhoneNumber](https://github.com/google/libphonenumber) at the backend.

- A valid email and a valid bank account number must pass validation before submitting the form.

- Customers are uniquely identified in the database based on a combination of `Firstname`, `Lastname`, and `DateOfBirth`.

- Email addresses are required to be unique in the database.

### Storage Optimization

- To optimize storage space, the application stores phone numbers in the database using either `ulong`, which occupies less space. This ensures efficient resource utilization.
