# Order API Documentation

## Overview

This document describes the CRUD (Create, Read, Update, Delete) operations available for managing orders.

## Base URL

The base URL for all endpoints is `/api/v1/orders`.

## Endpoints

### 1. Create an order

- **POST /api/v1/orders**
  - **Description:** Create an order.
  - **Request Body:**
    ```json
    {
      "customer_id": 1,
      "order_line_items": [
        { "product_id": 123, "quantity": 1, "price": 10 },
        { "product_id": 456, "quantity": 2, "price": 20 },
        { "product_id": 789, "quantity": 3, "price": 30 }
      ]
    }
    ```
  - **Response:**
    - **Status Code:**
      - 201 Created: Order created successfully.
      - 400 Bad Request: Invalid request format.

### 2. Retrieve orders

#### 2.1 Get order by ID

- **GET /api/v1/orders/{order_id}**
  - **Description:** Retrieve a specific order by ID.
  - **Parameter:**
    - `order_id`: ID of the order to retrieve.
  - **Response:**
    - **Status Code:**
      - 200 OK: Order retrieved successfully.
      - 404 Not Found: Order ID not found.
    - **Body:**
      ```json
      {
        "order_id": 1,
        "customer_id": 1,
        "order_date": "2024-04-22",
        "address_id": 1,
        "order_line_items": [
          { "product_id": 123, "quantity": 1, "price": 10 },
          { "product_id": 456, "quantity": 2, "price": 20 },
          { "product_id": 789, "quantity": 3, "price": 30 }
        ]
      }
      ```

#### 2.2 Get all orders by User ID

- **GET /api/v1/orders/user/{user_id}**
  - **Description:** Retrieve orders for a specific user.
  - **Parameter:**
    - `customer_id`: ID of the user.
  - **Response:**
    - **Status Code:**
      - 200 OK: Orders retrieved successfully.
      - 404 Not Found: User ID not found.
    - **Body:**
      ```json
      [
        {
          "order_id": 1,
          "customer_id": 1,
          "order_date": "2024-04-22",
          "address_id": 1,
          "order_line_items": [
            { "product_id": 123, "quantity": 1, "price": 10 },
            { "product_id": 456, "quantity": 2, "price": 20 },
            { "product_id": 789, "quantity": 3, "price": 30 }
          ]
        },
        ...
      ]
      ```

### 3. Update Order

- **PUT /api/v1/orders/{order_id}**
  - **Description:** Update an existing order by its ID.
  - **Parameter:**
    - `order_id`: ID of the order to update.
  - **Request Body:**
    ```json
    {
      "customer_id": 1,
      "order_line_items": [
        { "product_id": 123, "quantity": 2, "price": 15 },
        { "product_id": 456, "quantity": 1, "price": 25 }
      ]
    }
    ```
  - **Response:**
    - **Status Code:**
      - 200 OK: Order updated successfully.
      - 404 Not Found: Order not found.

### 4. Delete Order

- **DELETE /api/v1/orders/{order_id}**
  - **Description:** Delete a specific order by its ID.
  - **Parameter:**
    - `order_id`: ID of the order to delete.
  - **Response:**
    - **Status Code:**
      - 204 No Content: Order deleted successfully.
      - 404 Not Found: Order not found.
