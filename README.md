# Food Order API

This is a simple API for managing food orders, built with ASP.NET Core.

## Features

- User registration and authentication (with cookie-based authentication)
- CRUD operations for products
- User address and card management

## Representation of ERP Diagramme

![database sunum](https://github.com/user-attachments/assets/d6649187-53e0-4f36-be1c-52667a3d3027)


## Endpoints

### User

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/user/register` | Register a new user |
| `POST` | `/api/user/login` | Login a user |
| `POST` | `/api/user/logout` | Logout a user |
| `GET` | `/api/user/{id}` | Get user details |
| `PUT` | `/api/user/{id}` | Update user details |

### Products

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/product` | Get all products |
| `GET` | `/api/product/{id}` | Get a product by ID |
| `GET` | `/api/product/search` | Search products by name |
| `POST` | `/api/product` | Create a new product (Admin only) |
| `PUT` | `/api/product/{id}` | Update a product (Admin only) |
| `DELETE` | `/api/product/{id}` | Delete a product (Admin only) |

### User Addresses

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/user/addresses` | Get all addresses for a user |
| `POST` | `/api/user/addresses` | Add a new address |
| `PUT` | `/api/user/addresses/{id}` | Update an address |
| `DELETE` | `/api/user/addresses/{id}` | Delete an address |

### User Cards

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/user/cards` | Get all cards for a user |
| `POST` | `/api/user/cards` | Add a new card |
| `PUT` | `/api/user/cards/{id}` | Update a card |
| `DELETE` | `/api/user/cards/{id}` | Delete a card |

