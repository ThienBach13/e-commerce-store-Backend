# Authentication API Documentation

- [Authentication API Documentation](#authentication-api-documentation)
- [Overview](#overview)
  - [Base URL](#base-url)
  - [Authentication Endpoints Overview](#authentication-endpoints-overview)
- [Endpoints](#endpoints)
  - [User Registration](#user-registration)
    - [POST User Registration - Request](#post-user-registration---request)
    - [POST User Registration - Response](#post-user-registration---response)
  - [User Login](#user-login)
    - [GET User Login - Request](#get-user-login---request)
    - [GET User Login - Response](#get-user-login---response)
  - [Refresh Token](#refresh-token)
    - [POST Refresh Token - Request](#post-refresh-token---request)
    - [POST Refresh Token - Response](#post-refresh-token---response)
  - [User Logout](#user-logout)
    - [POST Logout - Request](#post-logout---request)
    - [POST Logout - Response](#post-logout---response)
  - [User Profile / Get User With Session](#user-profile--get-user-with-session)
    - [GET User Profile - Request](#get-user-profile---request)
    - [GET User Profile - Response](#get-user-profile---response)

# Overview

## Base URL

The base URL for all endpoints is `/api/v1/auth`.

## Authentication Endpoints Overview

| HTTP Method | Endpoint    | Description                              |
| ----------- | ----------- | ---------------------------------------- |
| POST        | `/register` | [Register as a user](#user-registration) |
| GET         | `/login`    | [User Login](#user-login)                |

# Endpoints

## User Registration

**Description:**
Endpoint to register a new user in the system.
If successful, response contains ID of newly created user.

### POST User Registration - Request

**Endpoint:**

```sh
POST /api/v1/auth/register
```

**Request Body:**

```json
{
  "email": "john.doe@example.com",
  "password": "strongpassword123"
}
```

### POST User Registration - Response

**Response Codes:**

```json
201 Created: User registered successfully.
400 Bad Request: Invalid request format or missing required fields.
409 Conflict: User with the same email already exists.
```

**Response Body:**

```json
{
  "id": 379,
  "email": "john.doe@example.com"
}
```

## User Login

**Description:** Authenticate and login a user.

### GET User Login - Request

**Endpoint:**

```sh
GET /api/v1/auth/login
```

**Request Body:**

```json
{
  "email": "john.doe@example.com",
  "password": "strongpassword123"
}
```

### GET User Login - Response

**Status Codes:**

```json
200 OK: User logged in successfully.
400 Bad Request: Invalid email or password provided.
401 Unauthorized: Authentication failed. Invalid credentials.
403 Forbidden: User account is inactive or suspended.
```

```yml
Location: {{host}}/api/v1/auth/login
```

**Response Body:**

```json
{
  "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImlhdCI6MTY3Mjc2NjAyOCwiZXhwIjoxNjc0NDk0MDI4fQ.kCak9sLJr74frSRVQp0_27BY4iBCgQSmoT3vQVWKzJg",
  "refresh_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImlhdCI6MTY3Mjc2NjAyOCwiZXhwIjoxNjcyODAyMDI4fQ.P1_rB3hJ5afwiG4TWXLq6jOAcVJkvQZ2Z-ZZOnQ1dZw"
}
```

## Refresh Token

**Description:**
To refresh an access token, the refresh token can be sent to the `/refresh_token` endpoint.

### POST Refresh Token - Request

**Endpoint:**

```sh
POST api/v1/auth/refresh_token
```

**Request body:**

```json
{
  "refresh_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImlhdCI6MTY3Mjc2NjAyOCwiZXhwIjoxNjcyODAyMDI4fQ.P1_rB3hJ5afwiG4TWXLq6jOAcVJkvQZ2Z-ZZOnQ1dZw"
}
```

### POST Refresh Token - Response

**Status Codes:**

```json
200 OK: Refresh token accepted;
400 Bad Request;
401 Unauthorized: Authentication failed. Invalid credentials;
```

```yml
Location: {{host}}/api/v1/auth/refresh_token
```

**Response Body:**
The response is a new set of tokens, like this:

```json
{
  "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImlhdCI6MTY3Mjc2NjAyOCwiZXhwIjoxNjc0NDk0MDI4fQ.kCak9sLJr74frSRVQp0_27BY4iBCgQSmoT3vQVWKzJg",
  "refresh_token": "jhEhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImlhdCI6MTY3Mjc2NjAyOCwiZXhwIjoxNjcyODAyMDI4fQ.P1_rB3hJ5afwiG4TWXLq6jOAcVJkvQZ2Z-ZZOnQ1dZw"
}
```

## User Logout

**Description:** Log out the currently authenticated user.

### POST Logout - Request

**Endpoint:**

```sh
POST /api/v1/auth/logout
```

**Requires authentication:** Yes.

```json
# Headers
{
  "Authorization": "Bearer {token}"
}
```

### POST Logout - Response

**Status Codes:**

```json
200 OK: User logged out successfully.
401 Unauthorized: The access token is missing or invalid.
403 Forbidden: The user is not authorized to log out.
```

**Response body:**

```json
{
  "success": true,
  "message": "Successfully signed out."
}
```

## User Profile / Get User With Session

**Description:** Get the profile information of the currently authenticated user.

### GET User Profile - Request

**Endpoint:**

```sh
GET /api/v1/auth/profile
```

**Requires authentication:** Yes.

```json
# Headers
"Authorization": "Bearer {token}"
```

### GET User Profile - Response

**Status Codes:**

```json
200 OK: User profile retrieved successfully;
404 Not Found: The user profile could not be found;
```

**Response Body:**

```json
{
  "id": 758,
  "user_role": "customer",
  "email": "john.doe@example.com",
  "password": "xxxxxxxxxxxxxx",
  "first_name": "John",
  "last_name": "Doe",
  "phone": "(040) 1313 006"
}
```
