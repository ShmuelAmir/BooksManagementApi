# Book Management API

This is a .NET Core project for managing books, fetching book information from the OpenLibrary API, and getting tags for them with imagga API.

## API Reference

#### Get all books

```http
  GET /api/book
```

#### Get book

```http
  GET /api/book/${id}
```

| Parameter | Type  | Description                       |
| :-------- | :---- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of book to fetch |

#### Add a book

```http
  POST /api/book
```

#### Update book details

```http
  PUT /api/book/${id}
```

| Parameter | Type  | Description                       |
| :-------- | :---- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of book to fetch |

#### Delete a book

```http
  DELETE /api/book/${id}
```

| Parameter | Type  | Description                       |
| :-------- | :---- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of book to fetch |

#### Fetch books by name or author

```http
  GET /api/openlibrarybook/${searchTerm}
```

| Parameter    | Type     | Description                       |
| :----------- | :------- | :-------------------------------- |
| `searchTerm` | `string` | **Required**. Book or author name |

#### Fetch tags for the image

```http
  GET /api/imagga/${imageUrl}
```

| Parameter  | Type     | Description                 |
| :--------- | :------- | :-------------------------- |
| `imageUrl` | `string` | **Required**. The image URL |

## Authors

- [@ShmuelAmir](https://www.github.com/ShmuelAmir)
- [@Chaim95](https://www.github.com/Chaim95)

## Features

- Fetching books from OpenLibraryApi
- Manage book details
- Get tags by Imagga AI

## License

[MIT](https://choosealicense.com/licenses/mit/)

## Run Locally

Clone the project

```bash
  git clone https://github.com/ShmuelAmir/BooksManagementApi.git
```

Go to the project directory

```bash
  cd my-project
```

Install dependencies

```bash
  dotnet restore
```

Start the server

```bash
  dotnet run
```

## Tech Stack

ASP.NET Core Web API, Entity Framework, Restsharp.
