# Dora Turizm - Hajj & Umrah Tour Management Platform

Dora Turizm is a web application designed to manage Hajj and Umrah tour services, offering a user-friendly interface, strong security features, and efficient management tools.

## Features

- **Admin Panel**: A centralized panel for managing content and user interactions.
- **JWT Authentication**: Secure authentication using access and refresh tokens.
- **Aspect-Oriented Programming (AOP)**: Modular code structure for cross-cutting concerns like authorization and logging.
- **Multi-Layered Architecture**: Separates data access, business logic, and presentation layers for a scalable and maintainable codebase.
- **Entity Framework Core**: Provides a powerful ORM for database operations.

## Technologies Used

| Technology                    | Description                                                                                                  |
|-------------------------------|--------------------------------------------------------------------------------------------------------------|
| **ASP.NET Core MVC**          | Utilizes the Model-View-Controller pattern for handling user interface and business logic.                   |
| **Entity Framework Core**      | Offers Object-Relational Mapping (ORM) for seamless database interactions.                                  |
| **JWT Authentication**        | Provides secure session management with access and refresh tokens.                                           |
| **Aspect-Oriented Programming (AOP)** | Handles cross-cutting concerns like security and error logging in a centralized way.             |
| **Multi-Layered Architecture** | Enables modular, maintainable code by separating concerns into distinct layers.                          |
| **Autofac**                    | Used for dependency injection and resolving dependencies across different layers in the application.          |
| **FluentValidation**           | Provides a fluent interface for defining validation rules for models and entities.                           |

## Project Architecture

The project follows a multi-layered architecture, ensuring separation of concerns and a clean code structure. The main layers are:

- **WebUI MVC**: The user interface layer, built using ASP.NET Core MVC, handles client-side interactions and displays data to the user.
- **WebAPI**: A set of RESTful APIs exposed for communication between the front end and backend services.
- **Business Layer**: Contains the core business logic and application-specific rules.
- **Core Layer**: Houses common utilities, constants, and shared resources used across other layers.
- **DataAccess Layer**: Responsible for interacting with the database, utilizing Entity Framework Core for ORM functionality.
- **Entity Layer**: Contains data models and entities that represent the database structure, used by the DataAccess layer.

## Screenshots

### User Interface

![DoraTurizm1](https://github.com/user-attachments/assets/c542268f-856b-4c44-b197-1da087d97840)  
|-------------------------------|
![DoraTurizm2](https://github.com/user-attachments/assets/c7e638a9-5720-4c75-a650-7c2c5805206e)  

![DoraTurizm3](https://github.com/user-attachments/assets/cb4b5839-2fee-45cc-834f-6aee6ed85c79)
|-------------------------------|

### Admin Interface

![DoraTurizmAdmin1](https://github.com/user-attachments/assets/16ac3bc6-f1a7-4c2a-8c02-def8fe7a1d68)  
|-------------------------------|
![DoraTurizmAdmin2](https://github.com/user-attachments/assets/2d8dd6cb-05a7-4d09-b72c-cdff655522f9)  
![DoraTurizmAdmin3](https://github.com/user-attachments/assets/4ff63c49-131b-4915-adc6-64dc293cede4)  
![DoraTurizmAdmin4](https://github.com/user-attachments/assets/500b7280-4564-4a94-8586-be6f47fce31a)

## Contributors

- **Harun Karagöz** - Developer

## License

This project is licensed under the [MIT License](./LICENSE).
