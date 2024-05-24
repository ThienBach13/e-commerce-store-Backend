# Products API Documentation

- [Products API Documentation](#products-api-documentation)
- [Overview](#overview)
  - [Base URL](#base-url)
  - [Products Endpoints Overview](#products-endpoints-overview)
- [Endpoints](#endpoints)
  - [Create a Product](#create-a-product)
    - [POST Create Product - Request](#post-create-product---request)
    - [POST Create Product - Response](#post-create-product---response)
      - [Sample response](#sample-response)
  - [Get Product by ID](#get-product-by-id)
    - [GET Product by ID - Request](#get-product-by-id---request)
    - [GET Product by ID - Response](#get-product-by-id---response)
      - [Sample response](#sample-response-1)
  - [Get All Products](#get-all-products)
    - [GET All Products - Request](#get-all-products---request)
    - [GET All Products - Response](#get-all-products---response)
      - [Sample response](#sample-response-2)
    - [GET All Products - Query Parameters](#get-all-products---query-parameters)
      - [Pagination](#pagination)
      - [Filter by Price Range](#filter-by-price-range)
      - [Filter by Category](#filter-by-category)
      - [Search by Name](#search-by-name)
      - [Sort by Price](#sort-by-price)
      - [Sort by Name](#sort-by-name)
  - [Update a Product](#update-a-product)
    - [PUT Update Product - Request](#put-update-product---request)
    - [PUT Update Product - Response](#put-update-product---response)
      - [Sample response](#sample-response-3)
  - [Delete a Product](#delete-a-product)
    - [DELETE product - Request](#delete-product---request)
    - [DELETE product - Response](#delete-product---response)

# Overview

## Base URL

The base URL for all endpoints is `/api/v1/products`.

## Products Endpoints Overview

| HTTP Method | Endpoint                              | Description                                                       |
| ----------- | ------------------------------------- | ----------------------------------------------------------------- |
| POST        | `/products`                           | [Create a product](#create-a-product)                             |
| GET         | `/products/:id`                       | [Get product by ID](#get-product-by-id)                           |
| GET         | `/products`                           | [Get all products](#get-all-products)                             |
| GET         | `/products?offset=125&limit=25`       | [Get all products; Pagination](#pagination)                       |
| GET         | `/products?price_min=30&price_max=49` | [Get all products; Filter by price range](#filter-by-price-range) |
| GET         | `/products?categories=3,7`            | [Get all products; Filter by categories](#filter-by-category)     |
| GET         | `/products?search=choco`              | [Search products by name](#search-by-name)                        |
| GET         | `/products?sort_by_price=asc`         | [Sort products by price](#sort-by-price)                          |
| GET         | `/products?sort_by_name=desc`         | [Sort products by name](#sort-by-name)                            |
| PUT         | `/products/:id`                       | [Update a product](#update-a-product)                             |
| DELETE      | `/products/:id`                       | [Delete a product](#delete-a-product)                             |

# Endpoints

## Create a Product

**Description**: Endpoint to create a new product. Requires authorization. Product information to be sent in request body. If successful, response body contains the ID of the newly created resource, along with the product object.

### POST Create Product - Request

**Endpoint**

```sh
POST /api/v1/products
```

**Authentication required**: Yes.

```json
# Headers
{
  "Authorization": "Bearer {token}"
}
```

**Request body:**

```json
{
  "name": "Product Name",
  "description": "Product Description",
  "price": 19.99,
  "category_id": 4,
  "quantity_in_stock": 0,
  "image": "http://placehold.it/kjasdf8h3"
}
```

### POST Create Product - Response

**Response codes:**

```js
201 Created;
401 Unauthorized;
403 Forbidden;
```

```yml
Location: {{host}}/api/v1/products
```

#### Sample response

`POST api/v1/products`

```json
{
  "id": 8320,
  "name": "Product Name",
  "description": "Product Description",
  "price": 19.99,
  "category_id": 4,
  "quantity_in_stock": 0,
  "image": "http://placehold.it/kjhfsd834hj54",
  "createdAt": "2024-04-29T10:15:30.0000000",
  "updatedAt": "2024-04-29T10:15:30.0000000"
}
```

## Get Product by ID

**Description:** Retrieves a specific product, identified by its product ID. Response displays the product object.

### GET Product by ID - Request

**Endpoint**

```sh
GET /api/v1/products/:productId
```

**Authentication required**: No.

**Request body:**

```json
{}
```

### GET Product by ID - Response

**Success code:**

```js
200 OK;
404 Not found;
```

```yml
Location: {{host}}/api/v1/products/:productId
```

#### Sample response

`GET /api/v1/products/8291`

```json
{
  "id": 8291,
  "name": "Whey Protein Isolate - Strawberry Flavour",
  "description": "Indulge in the delicious fusion of fitness and flavor with our Strawberry Whey Protein Isolate. Packed with pure protein power, this blend offers a fruity twist to your post-workout routine. Fuel your muscles with premium quality whey, crafted for optimal taste and performance. Elevate your fitness journey today!",
  "price": 29.99,
  "category_id": 4,
  "quantity_in_stock": 52,
  "image": "http://placehold.it/",
  "createdAt": "2024-04-29T10:15:30.0000000",
  "updatedAt": "2024-04-29T10:15:30.0000000"
}
```

## Get All Products

**Description:** Lorem ipsum

### GET All Products - Request

**Endpoint**

```sh
GET /api/v1/products
```

**Authentication required**: No.

**Request body:**

```json
{}
```

### GET All Products - Response

**Success code:**

```js
200 OK;
404 Not found;
```

```yml
Location: {{host}}/api/v1/products
```

#### Sample response

- **GET /api/v1/products/{product_id}**

  - **Description:** Retrieve a specific product by its ID.

  - **Parameters:**

    - `product_id`: The unique identifier for the product.

  - **Response:**
    - **Status Code:**
      - 200 OK: Successful retrieval.
      - 404 Not Found: Product not found.
    - **Body:**
      ```json
      {
        "id": 123,
        "name": "Product Name",
        "description": "Product Description",
        "price": 19.99,
        "category_id": 6,
        "quantity_in_stock": 20,
        "image": "http://placehold.it/"
      }
      ```

### GET All Products - Query Parameters

#### Pagination

**Description:**
Paginates the result set into pages with a specific number of results per page (specified by `limit` parameter), and to be browsed in order (specified by `offset` parameter).

**Parameters:**

- `offset`: Tells the API how many results to skip from beginning of result set.
- `limit` : Sets the maximum number of items to fetch in one go.

**Status Codes:**

```js
200 OK;
404 Not Found;
```

**Sample response:**

```json
GET /api/v1/products?offset=125&limit=25
```

```js
[
  {
    "id": 123,
    "name": "Product Name",
    "description": "Product Description",
    "price": 19.99,
    "category_id": 1,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/"
  },
  {
    "id": 456,
    "name": "Other product",
    "description": "something Description",
    "price": 29.99,
    "category_id": 1,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/"
  },
  {...} // and 23 products more
]
```

#### Filter by Price Range

**Description:**
Filter products that fall within a specified price range.

Standalone use of the minimum and maximum price filter is enabled. E.g., it is possible to only specify an upper or lower bound of prices.

**Parameters:**

- `price_min`: The minimum price above which all products in the result set must be priced.
- `price_max`: The maximum price below which all products in the result set must be priced.

**Status Codes:**

```js
200 OK;
400 Bad request; // Invalid min or max price parameter
```

**Sample response:**

```json
GET /api/v1/products?price_min=70&price_max=110
```

```json
[
  {
    "id": 123,
    "name": "Product Name",
    "description": "Product Description",
    "price": 89.99,
    "category_id": 12,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/908345kh234509"
  },
  {
    "id": 456,
    "name": "Another Product",
    "description": "Another Product Description",
    "price": 104.50,
    "category_id": 4,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/n5q3498unt34oi"
  },
  {...}
]
```

#### Filter by Category

**_Take note:_**
_To retrieve all of a single category's products, without any flexible filtering applied (e.g. `GET /api/v1/categories/:categoryId/products`), refer to the [Categories API Documentation](./CategoriesAPI.md#get-products-by-category)._

**Description:**
Filter products by their associated product category.

**Parameters:**

- `categories=3`: Filter by category with category ID 3
- `categories=2,7`: Filter by multiple categories

**Status Codes:**

```
200 OK;
400 Bad Request;
```

**Sample Response:**

```js
// GET /api/v1/products?categories={Array<catgoryId>}
GET /api/v1/products?categories=3,5&price_max=40
// Retrieves products from categories with category ID 3 and category ID 5
// which cost less than 40.
```

```json
[
  {
  "id": 123,
  "name": "Product Name",
  "description": "Product Description",
  "price": 100,
  "category_id": 3,
  "quantity_in_stock": 20,
  "image": "http://placehold.it/jhf098k"
  },
  {
  "id": 456,
  "name": "Another Product",
  "description": "Another Product Description",
  "price": 100,
  "category_id": 5,
  "quantity_in_stock": 20,
  "image": "http://placehold.it/kjn987345khj"
  }
  ...
]
```

#### Search by Name

**Description:**
Filter products by their name to match a text query.

**Parameters:**

- `search`: The search query string

**Status Codes:**

```js
200 OK;
400 Bad request; // Invalid query
```

**Sample response:**

```json
GET /api/v1/products?search=cal
```

```json
[
  {
    "id": 123,
    "name": "Blue California Surf T-Shirt, Size M",
    "description": "Product Description",
    "price": 29.99,
    "category_id": 2,
    "quantity_in_stock": 31,
    "image": "http://placehold.it/908345kh234509"
  },
  {
    "id": 567,
    "name": "Calisthenics Rubber Band for Home Workouts",
    "description": "Another Product Description",
    "price": 104.50,
    "category_id": 4,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/n5q3498unt34oi"
  },
  {...}
]
```

#### Sort by Price

**Description:**
Sort the result set of products by their price.
Defaults to ascending order (lowest prices first).

**Parameters:**

- `sort_by_price=asc`: Sort prices low to high
- `sort_by_price=desc`: Sort prices high to low

**Status Codes:**

```js
200 OK;
400 Bad request; // Invalid query
```

**Sample response:**

```json
GET /api/v1/products?sort_by_price=asc
```

```json
[
  {
    "id": 234,
    "name": "Cotton Pads",
    "description": "Product Description",
    "price": 0.39,
    "category_id": 2,
    "quantity_in_stock": 31,
    "image": "http://placehold.it/908345kh234509"
  },
  {
    "id": 346,
    "name": "Post-It Notes - White, non-sticky",
    "description": "Another Product Description",
    "price": 0.44,
    "category_id": 4,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/n5q3498unt34oi"
  },
  {...}
]
```

#### Sort by Name

**Description:**
Sort the result set of products by name.
Defaults to ascending order (A-Z).

**Parameters:**

- `sort_by_name=asc`: Sort by name in alphabetical order (A-Z).
- `sort_by_name=desc`: Sort by name in reverse-alphabetical order (Z-A).

**Status Codes:**

```js
200 OK;
400 Bad request; // Invalid query
```

**Sample response:**

```json
GET /api/v1/products?sort_by_name=asc
```

```json
[
  {
    "id": 123,
    "name": "AAA Batteries Maxi Pack: Panasonic UltraCharge 24 AAA Lithium Ion Batteries",
    "description": "Product Description",
    "price": 29.99,
    "category_id": 2,
    "quantity_in_stock": 31,
    "image": "http://placehold.it/908345kh234509"
  },
  {
    "id": 456,
    "name": "About You Woman's Summer Top - XS Navy Blue",
    "description": "Another Product Description",
    "price": 34.50,
    "category_id": 4,
    "quantity_in_stock": 20,
    "image": "http://placehold.it/n5q3498unt34oi"
  },
  {...}
]
```

## Update a Product

**Description:**
Update a specific product, identified by its ID. The fields to be updated are specified in the request body.
If successful, returns the entire updated resource object.

### PUT Update Product - Request

**Endpoint:**

```json
PUT api/v1/procucts/:productId
```

**Authentication required:** Yes.

```json
# Headers
{
  "Authorization": "Bearer {token}"
}
```

**Request Body:**

```js
{
  // any field except product ID can be updated
  "name": "Updated Product Name",
  "description": "Updated Product Description",
  "price": 24.99,
  "category_id": 2,
  "quantity_in_stock": 20,
  "image": "http://placehold.it/"
}
```

### PUT Update Product - Response

**Response Codes:**

```js
200 OK;
400 Bad Request; // e.g. invalid price was sent
401 Unauthorized;
403 Forbidden;
404 Product not found;
```

```yml
Location: {{host}}/api/v1/products
```

#### Sample response

**Request Body:**

```json
{
  "id": 651,
  "name": "Updated Product Name",
  "description": "Updated Product Description",
  "price": 24.99,
  "category_id": 2,
  "quantity_in_stock": 20,
  "image": "http://placehold.it/",
  "createdAt": "2024-01-01T00:59:59.0000000",
  "updatedAt": "2024-04-29T10:15:30.0000000"
}
```

## Delete a Product

**Description**:
Endpoint to delete a product, to be specified by its unique product ID.
Requires authorization.

### DELETE product - Request

**Endpoint**

```sh
DELETE /api/v1/products/:productId
```

**Authentication required**: Yes.

```json
# Headers
{
  "Authorization": "Bearer {token}"
}
```

**Request body:**

```json
{}
```

### DELETE product - Response

**Response Codes:**

```json
204 No Content: Product deleted successfully;
401 Unauthorized;
403 Forbidden;
404 Product not found.
```

```yml
Location: {{host}}/api/v1/products
```

**Response Body:**

```json
{}
```
