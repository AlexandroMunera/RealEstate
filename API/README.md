# RealEstateAPI

## Overview

RealEstateAPI is a web application designed to manage real estate properties and their owners. It provides a RESTful API for performing CRUD operations on properties and owners, utilizing MongoDB for data storage and Entity Framework Core for database interactions.

## Getting Started

### Prerequisites

- .NET SDK (version 8.0 )
- MongoDB server

### Installation

1. Clone the repository:

   ```
   git clone https://github.com/AlexandroMunera/RealEstateAPI.git
   cd RealEstateAPI
   ```

2. Restore the dependencies:

   ```
   dotnet restore
   ```

3. Update the `appsettings.json` file with your MongoDB connection string and database name.

   ```
   "AllowedHosts": "*",
   "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "Database": "real-estate"
   }
   ```

### Running the Application

To run the application, use the following command:

```
dotnet run
```

### Testing

To run the unit and integration tests, use the following command:

```
dotnet test
```

## API Endpoints

- **Properties**

  - `GET /properties`: Retrieve a list of properties.
  - `GET /properties/{id}`: Retrieve a specific property by ID.
  - `POST /properties`: Create a new property.
  - `PUT /properties/{id}`: Update an existing property.
  - `DELETE /properties/{id}`: Delete a property.

- **Owners**
  - `GET /owners`: Retrieve a list of owners.
  - `POST /owners`: Create a new owner.
  - `PUT /owners/{id}`: Update an existing owner.
  - `DELETE /owners/{id}`: Delete an owner.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes. It will help me a lot 🫂.

## License

This project is licensed under the MIT License.
