# ECommerce 🛍️

ECommerce is a full-stack e-commerce application with a layered architecture.  
The backend is built with **ASP.NET Core Web API, Entity Framework Core, and Identity + JWT**, and the frontend is a **React + TypeScript + Vite** client using Material UI.

## 🌐 Overview

The app provides a basic online store experience:

- Browse products and view product details
- Add/remove items in a shopping cart
- Create orders from the current cart
- Register and log in with user accounts
- Use JWT-based authentication and roles on the API side

The solution is organized into separate projects for core abstractions, data access, business services, the Web API, and the React client.

## ✨ Features

- 🧾 **Product & category management**
  - Product listing and detail endpoints
  - Category CRUD via the API
  - Auto-included product → category navigation (EF Core)

- 🛒 **Shopping cart**
  - Add items, remove items, and clear cart
  - Cart stored in server session with a helper (`CartSessionHelper`)
  - Cart service with business rules and DTOs

- 📦 **Orders**
  - Create order from the current cart and authenticated user
  - Retrieve single order or list of orders via API

- 👤 **Authentication & authorization**
  - ASP.NET Core Identity with a custom `User` entity (first name, last name, city, birth date)
  - JWT token generation and validation
  - Role services and controllers for user/role management
  - FluentValidation for request DTO validation

- 🧬 **Frontend client**
  - React + TypeScript SPA
  - Product list and product details pages
  - Shopping cart page with quantity controls and price summary
  - Login and registration pages
  - Basic layout with header, navigation, and error pages

## 🛠 Tech Stack

- **Backend**
  - ASP.NET Core Web API
  - Entity Framework Core
  - ASP.NET Core Identity
  - JWT authentication
  - FluentValidation
  - AutoMapper
  - SQL Server

- **Frontend**
  - React + TypeScript
  - Vite
  - Redux Toolkit
  - React Router
  - Material UI (MUI) + Emotion
  - Axios
  - React Toastify

## 📂 Project Structure

```text
ECommerce/
├── ECommerce.sln                     # .NET solution
├── ECommerce.Core/                   # Core abstractions & infrastructure
│   ├── Entities/                     # Base entity types
│   ├── Exceptions/                   # Business/authorization/not-found exceptions
│   ├── Repositories/                 # Generic repository abstractions & base EF repo
│   ├── Responses/                    # Standardized return models
│   └── Tokens/                       # Token options & helpers
├── ECommerce.Models/                 # Domain entities & DTOs
│   └── Entities/                     # Product, Category, Order, Cart, CartItem, User
├── ECommerce.DataAccess/             # EF Core data access layer
│   ├── Abstracts/                    # Repository interfaces
│   ├── Concretes/                    # EF repository implementations & UnitOfWork
│   ├── Configurations/               # EF model configurations for entities
│   ├── Contexts/                     # BaseDbContext (IdentityDbContext + DbSets)
│   └── Migrations/                   # EF Core migrations & snapshots
├── ECommerce.Service/                # Business/service layer
│   ├── Abstracts/                    # Service interfaces (product, category, cart, order, auth, user, role)
│   ├── Concretes/                    # Service implementations
│   ├── Rules/                        # Business rule classes
│   ├── Profiles/                     # AutoMapper profiles
│   └── Validations/                  # FluentValidation validators for request DTOs
├── ECommerce.WebApi/                 # ASP.NET Core Web API
│   ├── Controllers/                  # Products, Categories, Cart, Orders, Users, Roles, Authentication
│   ├── Helpers/                      # CartSessionHelper & related utilities
│   ├── Middlewares/                  # Global exception handling, etc.
│   ├── appsettings*.json             # Configuration (TokenOption, SQL connection string)
│   └── Program.cs                    # Service registration & HTTP pipeline (Identity, JWT, CORS, session)
└── ecommerce.client/                 # React + TypeScript frontend
    ├── package.json
    ├── index.html
    ├── vite.config.ts
    └── src/
        ├── api/requests.ts          # Axios client & API helpers
        ├── layouts/App.tsx          # Root layout & router outlet
        ├── layouts/Header.tsx       # MUI app bar & navigation
        ├── features/
        │   ├── HomePage.tsx
        │   ├── ContactPage.tsx
        │   ├── AboutPage.tsx
        │   ├── product/             # Product list, details, slice
        │   ├── cart/                # Cart page & slice
        │   └── authentication/      # Login, register, auth slice
        ├── errors/                  # NotFound, ServerError
        ├── router/Routes.tsx        # Route definitions
        ├── store/store.ts           # Redux Toolkit store
        └── utils/formatCurrency.ts  # Currency formatting helpers
