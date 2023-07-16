# Movie Directory

This repository contains code for a Movie Directory application. The application includes a backend API for retrieving movie information and a frontend UI built with React.

## Backend API

### MoviesController

The `MoviesController` class handles movie-related operations. It includes the following endpoints:

- **Search Movies** - `GET /api/movies/search`
  - Parameters:
    - `query` (string): The search query for movies.
    - `page` (int): The page number for pagination.
  - Returns:
    - If the search is successful, the method returns a response with a list of movies.
    - If an error occurs during the search, the method returns an appropriate error response.

- **Find Movie by ID** - `GET /api/movies/{id}`
  - Parameters:
    - `id` (string): The ID of the movie to retrieve.
  - Returns:
    - If the movie is found, the method returns a response with the movie details.
    - If the movie is not found or an error occurs, the method returns an appropriate error response.

### QueryController

The `QueryController` class handles search query-related operations. It includes the following endpoint:

- **Get Search Queries** - `GET /api/query`
  - Returns:
    - Retrieves a list of search queries made by users.

## Frontend UI

The frontend UI is built with React and includes two components:

- **MovieDirectory**: This component displays a list of movies and allows users to search for movies. It is rendered at the root URL ("/").
- **MovieDetails**: This component displays detailed information about a specific movie. It is rendered when a user navigates to the "/movie/:id" URL, where ":id" is the ID of the movie.

## Prerequisites

To run the application, ensure you have the following dependencies installed:

- Node.js
- React
- react-router-dom

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/movie-directory.git
2. Navigate to project directory:
   ```bash
   cd movie-directory
3. Install dependencies:
   ```bash
   npm install
## Usage
1. Start the backend API server:
    - Navigate to the backend directory:
    ```bash
    cd backend
    ```
    - Run the server:
    ```bash
    dotnet run
    ```
2. Start the frontend development server:
    - Navigate to the frontend directory:
    ```bash
    cd frontend
    ```
    - Run the development server:
    ```bash
    npm start
    ```
3. Access the Movie Directory application in your web browser at 'http://localhost:3000'

## License
This code is released under the <u>MIT License</u>
