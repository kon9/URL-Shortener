

# URL Shortener
![Screenshot 2023-03-27 at 00-48-15 React App](https://user-images.githubusercontent.com/38664747/227794517-244b90b0-b48f-4c97-bfcd-7504d98b5db6.png)

This project is a simple URL shortener built using ASP.NET Core for the backend API and React for the frontend. The URL shortener allows users to enter a long URL and receive a shorter version, which redirects to the original URL when accessed.

## Features

- Shorten long URLs
- Customizable URL conversion algorithms for flexibility
- Uses SQLite and Entity Framework Core for data storage
- Centralized exception handling with custom middleware

# Backend

- The backend is built using ASP.NET Core and consists of the following components:
- UrlController: Handles incoming HTTP requests and routes them to the appropriate service
- UrlShorteningService: Contains the core logic for URL shortening and conversion
- UrlRepository: Handles data access and storage using Entity Framework Core and SQLite
- ExceptionHandlingMiddleware: Custom middleware for centralized exception handling
  
