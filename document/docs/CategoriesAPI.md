# Category API Documentation

- [Category API Documentation](#category-api-documentation)
- [Overview](#overview)
  - [Base URL](#base-url)
  - [Categories Endpoints Overview](#categories-endpoints-overview)
- [Endpoints](#endpoints)
  - [Create Category](#create-category)
    - [POST Create Category - Request](#post-create-category---request)
    - [POST Create Category - Response](#post-create-category---response)
      - [Sample response](#sample-response)
  - [Get All Categories](#get-all-categories)
    - [GET All Categories - Request](#get-all-categories---request)
    - [GET All Categories - Response](#get-all-categories---response)
      - [Sample response: No query parameters](#sample-response-no-query-parameters)
      - [Sample response: Sorting](#sample-response-sorting)
      - [Sample response: Search filter](#sample-response-search-filter)
  - [Get Category by ID](#get-category-by-id)
    - [GET Category by ID - Request](#get-category-by-id---request)
    - [GET Category by ID - Response](#get-category-by-id---response)
      - [Sample response:](#sample-response-1)
  - [Get Products by Category](#get-products-by-category)
    - [GET Products by Category - Request](#get-products-by-category---request)
    - [GET Products by Category - Response](#get-products-by-category---response)
      - [Sample response](#sample-response-2)
  - [Update Category](#update-category)
    - [PATCH Update Category - Request](#patch-update-category---request)
    - [PATCH Update Category - Response](#patch-update-category---response)
      - [Sample response](#sample-response-3)
  - [Delete Category](#delete-category)
    - [DELETE Category - Request](#delete-category---request)
    - [DELETE Category - Response](#delete-category---response)
      - [Sample response](#sample-response-4)

# Overview

## Base URL

The base URL for all endpoints is `/api/v1/categories`.

## Categories Endpoints Overview

| HTTP Method | Endpoint                 | Description                                           |
| ----------- | ------------------------ | ----------------------------------------------------- |
| POST        | /categories              | [Create category](#create-a-category)                 |
| GET         | /categories              | [Get all categories](#get-all-categories)             |
| GET         | /categories/:id          | [Get category by ID](#get-a-single-category)          |
| GET         | /categories/:id/products | [Get products by category](#get-products-by-category) |
| PATCH       | /categories/:id          | [Update category](#update-category)                   |
| DELETE      | /categories/:id          | [Delete category](#delete-category)                   |

# Endpoints

## Create Category

**Description:** Creates a new category with the given name, description text and image URL. If successful, returns the newly created ID with the created resource object.

### POST Create Category - Request

**Endpoint:**

```sh
POST /api/v1/categories
```

**Authentication required**: Yes.

**Request body:**

```json
{
  "name": "Car Parts",
  "description": "Category description text...",
  "image": "https://imgur.com/ß123498-987234hk1239874j98234"
}
```

### POST Create Category - Response

**Response codes:**

```js
201 Created;
401 Unauthorized;
403 Forbidden;
```

```yml
Location: {{host}}/api/v1/categories
```

#### Sample response

`POST /api/v1/categories`

```json
{
  "id": 8,
  "name": "Car Parts",
  "description": "Category description text...",
  "image": "https://imgur.com/ß123498-987234hk1239874j98234"
}
```

## Get All Categories

**Description:** Retrieves a list of all categories, and displays the entire category object (ID, Name, Description, Image URL).

### GET All Categories - Request

**Endpoint:**

```sh
GET /api/v1/categories
```

**Authentication required**: No.

**Request body:**

```json
{}
```

**Optional parameters:**

- Sorting
  - `sort_by=`: Sort categories by `name` or `id` field.
  - `sort_order=`: Specify the sorting order of the response in combination with the `sort_by` parameter. Accepted values: `ASC` or `DESC`. If 'sort_by' is specified, but no 'sort_order' is specified, defaults to 'ASC'.
- Searching / Filtering
  - `search=`: Provides text-based filtering on the `name` field of the categories resource.

### GET All Categories - Response

**Success code:**

```js
200 OK
```

```yml
Location: {{host}}/api/v1/categories
```

#### Sample response: No query parameters

`GET /api/v1/categories`

```json
[
{
"id": 1,
"name": "Shoes",
"description": "Category Description text..."
"image": "URL_to_image",
},
{
"id": 2,
"name": "Suits",
"description": "Category Description text..."
"image": "URL_to_image",
},
...
]

```

#### Sample response: Sorting

`GET /api/v1/categories?sort_by=id&sort_order=DESC`

```json
[
{
"id": 7,
"name": "Accessories",
"description": "Category Description text..."
"image": "URL_to_image",
},
{
"id": 6,
"name": "Outerwear",
"description": "Category Description text..."
"image": "URL_to_image",
},
...
]

```

#### Sample response: Search filter

`GET /api/v1/categories?search=S&sort_by=name&sort_order=DESC`

```json
[
{
"id": 2,
"name": "Suits",
"description": "Category Description text..."
"image": "URL_to_image",
},
{
"id": 1,
"name": "Shoes",
"description": "Category Description text..."
"image": "URL_to_image",
},
...
]

```

## Get Category by ID

**Description:** Retrieves a specific categoriy identified by its ID, and displays the entire category object (ID, Name, Description, Image URL).

### GET Category by ID - Request

**Endpoint:**

```sh
GET /api/v1/categories/:categoryId
```

**Authentication required**: No.

**Request body:**

```json
{}
```

### GET Category by ID - Response

**Success code:**

```js
200 OK
```

```yml
Location: {{host}}/api/v1/categories/:categoryId
```

#### Sample response:

`GET /api/v1/categories/1`

```json
{
"id": 1,
"name": "Shoes",
"description": "Category Description text..."
"image": "URL_to_image",
}
```

## Get Products by Category

**Endpoint:**

```sh
GET /api/v1/categories/:categoryId/products
```

**Authentication required**: No.

**Description:** Retrieves a list of products belonging to the specified category (identified by path parameter `categoryId`).
Displays the entire category object (ID, Name, Description, Image URL).

**Request body:**

```json
{}
```

### GET Products by Category - Request

### GET Products by Category - Response

#### Sample response

## Update Category

**Description:** Update a specific category, identified by its ID. The fields to be updated are specified in the request body.
If successful, returns the entire updated resource object.

### PATCH Update Category - Request

**Endpoint:**

```sh
PATCH /api/v1/categories/:categoryId
```

**Authentication required**: Yes.

**Request body:**

```json
{
  "name": "Updated Category Name",
  "image": "Updated_URL_to_image",
  "description": "Updated Category Description"
}
```

Example body to update description and image fields:

```json
{
  "description": "Step into sophistication with our curated collection of suits for men. Elevate your style game with impeccably tailored suits crafted from premium materials, designed to fit in smart casual and professional occasions. From classic black suits and navy suits to bold patterns and contemporary cuts, we offer a diverse range to suit every taste and occasion. Whether you're dressing for the boardroom, a formal event, a wedding, or a special occasion, our suits are guaranteed to make a statement. Browse our extensive selection of suits now and discover the perfect ensemble to elevate your wardrobe.",
  "image": "https://imgur.com/ß123498-987234hk1239874j98234"
}
```

### PATCH Update Category - Response

**Success code:**

```js
200 OK
```

```yml
Location: {{host}}/api/v1/categories/:categoryId
```

#### Sample response

```json
{
  "id": 2,
  "name": "Suits",
  "description": "Step into sophistication with our curated collection of suits for men. Elevate your style game with impeccably tailored suits crafted from premium materials, designed to fit in smart casual and professional occasions. From classic black suits and navy suits to bold patterns and contemporary cuts, we offer a diverse range to suit every taste and occasion. Whether you're dressing for the boardroom, a formal event, a wedding, or a special occasion, our suits are guaranteed to make a statement. Browse our extensive selection of suits now and discover the perfect ensemble to elevate your wardrobe.",
  "image": "https://imgur.com/ß123498-987234hk1239874j98234"
}
```

## Delete Category

**Description:** Delete a specific category, identified by its ID.

### DELETE Category - Request

**Endpoint:**

```sh
DELETE /api/v1/categories/:categoryId
```

**Authentication required**: Yes.

**Request body:**

```json
{}
```

### DELETE Category - Response

**Success code:**

```js
200 OK
```

```yml
Location: {{host}}/api/v1/categories/:categoryId
```

#### Sample response

```json
{}
```
