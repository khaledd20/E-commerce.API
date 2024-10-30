# E-commerce API

## Overview
The **E-commerce API** is a powerful backend service built with .NET for managing an online store. It provides endpoints for handling essential operations related to products, users, orders, and payments. Designed with scalability, security, and flexibility in mind, this API is a perfect foundation for building a modern e-commerce platform.

## Features
- **Product Management**: Create, update, delete, and list products.
- **User Management**: Secure user registration, login, and role-based access control.
- **Order Processing**: Manage customer orders, including order creation, tracking, and status updates.
- **Payment Integration**: Supports integration with major payment gateways.
- **Authentication**: JWT-based authentication for secure API access.
- **Role-Based Access Control (RBAC)**: Admin and user roles for managing permissions.
- **Inventory Management**: Track stock levels, prevent overselling, and manage restocking.
- **Scalability**: Built to handle high-traffic scenarios with scalable architecture.

## Tech Stack
- **.NET Core**: Backend framework.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database.
- **JWT**: Authentication.
- **Swagger**: API documentation and testing.

## Installation

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 or later.
- SQL Server or any other supported database.
- [Postman](https://www.postman.com/downloads/) or any other API testing tool.

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ecommerce-api.git
   ```

2. Navigate into the project directory:
   ```bash
   cd ecommerce-api
   ```

3. Install dependencies:
   ```bash
   dotnet restore
   ```

4. Set up the database:
   - Update the connection string in `appsettings.json`.
   - Run the following command to apply migrations:
     ```bash
     dotnet ef database update
     ```

5. Run the project:
   ```bash
   dotnet run
   ```

6. Open your browser or Postman and navigate to:
   ```
   http://localhost:5000/swagger
   ```
   This will open the Swagger UI where you can explore and test the available API endpoints.

## Usage

### Endpoints

- **Products**
  - `GET /api/products` - List all products.
  - `POST /api/products` - Create a new product (Admin only).
  - `PUT /api/products/{id}` - Update a product (Admin only).
  - `DELETE /api/products/{id}` - Delete a product (Admin only).

- **Users**
  - `POST /api/auth/register` - Register a new user.
  - `POST /api/auth/login` - User login to get a JWT token.
  
- **Orders**
  - `POST /api/orders` - Create a new order.
  - `GET /api/orders` - Get all orders (Admin only).

For a full list of API endpoints, refer to the Swagger documentation.

## Contributing
Contributions are welcome! To get started:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.


