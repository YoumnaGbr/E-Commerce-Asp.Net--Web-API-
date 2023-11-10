# -	E-Commerce Asp.Net- Web API 

## Description

An online database of information related to Shop Products from the online shopping cart and details of each product.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Project Architecture](#project-architecture)
- [Backend (ASP.NET Web API)](#backend-aspnet-web-api)
- [Frontend (Angular)](#frontend-angular)
- [Authentication](#authentication)
- [Database](#database)
- [Usage](#usage)
- [Acknowledgments](#acknowledgments)
- [Contact](#contact)

## Getting Started

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **Visual Studio:** Install Visual Studio from [visualstudio.com](https://visualstudio.microsoft.com/). The project was developed with Visual Studio any version.
- **.NET SDK:** Install the .NET SDK from [dotnet.microsoft.com](https://dotnet.microsoft.com/download). The project was developed with .NET SDK version .NET 6.
- **Database:** Set up a compatible relational database (SQL Server) and configure the connection string in the `appsettings.json` file.

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-project.git

## Project Architecture

### Backend (ASP.NET Web API)

- Onion Architecture
- Specification Design Pttern
- Repository with Unit of Work

## Authentication

User authentication is implemented using JWT (JSON Web Tokens). Include details on token generation, validation, and storage.

## Database

Using SQL Server, Create database code first using Entity Framework.

## Usage

### Backend (ASP.NET Web API)

1. **Run the API Server:**
   - Ensure the ASP.NET Web API server is running. You can typically access it at `http://localhost:5000` (or another specified port).

2. **API Endpoints:**
   - Explore the available API endpoints for managing products, orders, and user-related actions.
     - Example: `GET http://localhost:5000/api/products` retrieves a list of all products.

3. **Authentication:**
   - To access protected endpoints, include the JWT token in the Authorization header of your requests.
     - Example: `Authorization: Bearer YOUR_JWT_TOKEN`

### Frontend (Angular)

1. **Run the Angular App:**
   - Navigate to the `frontend` directory.
   - Run `npm start` or `ng serve` to start the Angular development server.
   - Access the app at `http://localhost:4200` (or another specified port).

2. **Explore the User Interface:**
   - Navigate through the user interface to view products, add items to the cart, and complete the checkout process.

3. **User Authentication:**
   - Register for a new account or log in using existing credentials.
   - Upon successful authentication, you should receive a JWT token for accessing protected API endpoints.

4. **Product Management:**
   - If you have administrative privileges, explore features related to product management, such as adding new products or updating existing ones.

5. **Shopping Cart:**
   - Add products to the shopping cart, update quantities, and proceed to checkout.

6. **Order Placement:**
   - Complete the checkout process to place an order. Ensure that the order details are correctly processed on the backend.

7. **View Order History:**
   - If implemented, explore the functionality to view order history and track the status of previous orders.

## Acknowledgments
Special thanks to Route Academy for their invaluable contributions.

## Contact
If you have any questions or need further assistance, feel free to contact the project maintainer at youmna.gabr97.com.
