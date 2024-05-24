# User API Documentation

- [User API Documentation](#user-api-documentation)
- [Overview](#overview)
  - [Base URL](#base-url)
  - [Endpoints Overview](#endpoints-overview)
- [Endpoints](#endpoints)
  - [Create a User](#create-a-user)
    - [POST Create a User - Request](#post-create-a-user---request)
    - [POST Create a User - Response](#post-create-a-user---response)
  - [Get a User](#get-a-user)
    - [GET User by ID - Request](#get-user-by-id---request)
    - [GET User by ID - Response](#get-user-by-id---response)
      - [2.2 Read all users](#22-read-all-users)
  - [Get All Users](#get-all-users)
    - [GET All Users - Request](#get-all-users---request)
    - [GET All Users - Response](#get-all-users---response)
    - [3. Update a user](#3-update-a-user)
    - [4. Delete a user](#4-delete-a-user)

# Overview

This document describes the CRUD (Create, Read, Update, Delete) operations available for managing users.

## Base URL

The base URL for all endpoints is `/api/v1/users`.

## Endpoints Overview

# Endpoints

## Create a User

**Description:**
**Description:** Create a new user.

### POST Create a User - Request

**Endpoint:**

```sh
POST /api/v1/users
```

**Authentication required:** Yes.

```js
// Header
{
  "Authorization": "Bearer {token}"
}
```

**Request Body:**

```json
{
  "user_role": "customer",
  "first_name": "John",
  "last_name": "Doe",
  "email": "john.doe@example.com",
  "password": "strongpassword123"
}
```

### POST Create a User - Response

**Status Codes:**

```js
201 Created; // User created successfully;
400 Bad Request; // Invalid request format;
```

```yml
Loction: {{host}}/api/v1/users
```

**Response Body:**

```json
{
  "id": 17,
  "user_role": "customer",
  "first_name": "John",
  "last_name": "Doe",
  "email": "john.doe@example.com",
  "password": "strongpassword123"
}
```

## Get a User

**Description:**

### GET User by ID - Request

**Endpoint:**

**Authentication required:** Yes.

**Request body:**

### GET User by ID - Response

- **GET /api/v1/users/{user_id}**
  - **Description:** Retrieve a specific user by ID.
  - **Parameters:**
    - `user_id`: ID of the user to retrieve.
  - **Response:**
    - **Status Code:**
      - 200 OK: User retrieved successfully.
      - 404 Not Found: User ID not found.
    - **Body:**
      ```json
      {
        "id": "unique_id",
        "first_name": "John",
        "last_name": "Doe",
        "email": "john.doe@example.com",
        "phone": "0123456"
      }
      ```

#### 2.2 Read all users

## Get All Users

**Description:**

### GET All Users - Request

**Endpoint:**

**Authentication required:** Yes.

**Request body:**

### GET All Users - Response

- **GET /api/v1/users/**
  - **Description:** Retrieve all users.
  - **Response:**
    - **Status Code:**
      - 200 OK: Users retrieved successfully.
      - 404 Not Found: No users found.
    - **Body:**
      ```json
      [
        {
          "id": "unique_id_1",
          "first_name": "John",
          "last_name": "Doe",
          "email": "john.doe@example.com",
          "phone": "0123456"
        },
        {
          "id": "unique_id_2",
          "first_name": "Linda",
          "last_name": "Smith",
          "email": "linda.smith@example.com",
          "phone": "0654321"
        },
        ...
      ]
      ```

### 3. Update a user

- **PUT /api/v1/users/{user_id}**
  - **Description:** Update an existing user by ID.
  - **Parameters:**
    - `user_id`: ID of the user to update.
  - **Request Body:**
    ```json
    {
      "first_name": "Updated first name",
      "last_name": "Updated last name",
      "email": "updated.email@example.com"
    }
    ```
  - **Response:**
    - **Status Code:**
      - 200 OK: User updated successfully.
      - 404 Not Found: User ID not found.
    - **Body:**
      ```json
      {
        "id": "unique_id",
        "first_name": "Updated first name",
        "last_name": "Updated last name",
        "email": "updated.email@example.com",
        "email": "john.doe@example.com",
        "password": "strongpassword123"
      }
      ```

### 4. Delete a user

- **DELETE /api/v1/users/{user_id}**
  - **Description:** Delete a user by ID.
  - **Parameters:**
    - `user_id`: ID of the user to delete.
  - **Response:**
    - **Status Code:**
      - 204 No Content: User deleted successfully.
      - 404 Not Found: User ID not found.
