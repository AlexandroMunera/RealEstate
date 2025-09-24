# 🏠 Real Estate Management System

A full-stack real estate management application built with .NET 8 API, React TypeScript frontend, and MongoDB database. This system allows users to manage real estate properties and their owners with complete CRUD operations.

## 🖼️ Preview

<div align="left">
  <img src="2025-09-23_20-08-28 (1).gif" alt="Real Estate Management System Preview" width="700" height="600">
</div>

## ✨ Features

- **Property Management**: Create, read, update, and delete real estate properties
- **Owner Management**: Manage property owners with detailed information
- **Property Search & Filtering**: Advanced search and filtering capabilities
- **Property Details View**: Detailed view for individual properties
- **Responsive Design**: Modern, responsive UI built with React
- **RESTful API**: Clean API architecture with proper error handling
- **Database Integration**: MongoDB with Entity Framework Core
- **Testing**: Comprehensive test suites for both API and frontend

## 🏗️ Architecture

```
RealEstate/
├── API/                    # .NET 8 Web API
│   ├── Models/            # Data models (Property, Owner)
│   ├── Data/              # Database context
│   ├── Utils/             # Utilities and converters
│   └── Tests/             # API unit tests
├── Front/                 # React TypeScript Frontend
│   ├── src/
│   │   ├── components/    # Reusable UI components
│   │   ├── hooks/         # Custom React hooks
│   │   ├── pages/         # Application pages
│   │   ├── services/      # API integration
│   │   └── types/         # TypeScript type definitions
│   └── public/            # Static assets
└── TestsAPI/              # Additional API tests
```

## 🛠️ Tech Stack

### Backend
- **.NET 8**: Web API framework
- **MongoDB**: NoSQL database
- **Entity Framework Core**: ORM with MongoDB provider
- **Swagger/OpenAPI**: API documentation
- **xUnit**: Testing framework

### Frontend
- **React 19**: UI framework
- **TypeScript**: Type-safe JavaScript
- **Vite**: Build tool and dev server
- **Jest**: Testing framework
- **Testing Library**: Component testing utilities
- **ESLint**: Code linting

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (version 18 or higher)
- [pnpm](https://pnpm.io/) package manager
- [MongoDB](https://www.mongodb.com/) server

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AlexandroMunera/RealEstate.git
cd RealEstate
```

### 2. Setup MongoDB

Make sure MongoDB is running on your system. The default connection string expects MongoDB to be running on `localhost:27017`.

### 3. Backend Setup

```bash
# Navigate to API directory
cd API

# Restore dependencies
dotnet restore

# Update appsettings.json with your MongoDB connection string
# Edit appsettings.json and configure:
# {
#   "MongoDb": {
#     "ConnectionString": "mongodb://localhost:27017",
#     "Database": "RealEstateDB"
#   }
# }

# Run the API
dotnet run
```

The API will be available at `https://localhost:7234` and Swagger documentation at `https://localhost:7234/swagger`.

### 4. Frontend Setup

```bash
# Navigate to frontend directory
cd Front

# Install dependencies
pnpm install

# Start the development server
pnpm dev
```

The frontend will be available at `http://localhost:5173`.

## 🧪 Running Tests

### Backend Tests

```bash
# Run API tests
cd API
dotnet test

# Run additional tests
cd ../TestsAPI
dotnet test
```

### Frontend Tests

```bash
cd Front
pnpm test
```

## 📖 API Endpoints

### Properties
- `GET /api/properties` - Get all properties with optional filtering
- `GET /api/properties/{id}` - Get property by ID
- `POST /api/properties` - Create new property
- `PUT /api/properties/{id}` - Update property
- `DELETE /api/properties/{id}` - Delete property

### Owners
- `GET /api/owners` - Get all owners
- `GET /api/owners/{id}` - Get owner by ID
- `POST /api/owners` - Create new owner
- `PUT /api/owners/{id}` - Update owner
- `DELETE /api/owners/{id}` - Delete owner

## 🎯 Usage Examples

### Creating a Property

```bash
curl -X POST "https://localhost:7234/api/properties" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Beautiful Family Home",
    "address": "123 Main Street",
    "price": 450000,
    "codeInternal": "PROP001",
    "year": 2020,
    "imageUrl": "https://images.unsplash.com/photo-1570129477492-45c003edd2be"
  }'
```

### Filtering Properties

The API supports filtering properties by various criteria through query parameters:

- Price range: `?minPrice=100000&maxPrice=500000`
- Year: `?year=2020`
- Name search: `?name=family`

## 📁 Project Structure Details

### Data Models

**Property Model:**
- `Id`: Unique identifier
- `Name`: Property name
- `Address`: Property address
- `Price`: Property price
- `CodeInternal`: Internal property code
- `Year`: Year built
- `ImageUrl`: Property image URL
- `IdOwner`: Reference to owner

**Owner Model:**
- `Id`: Unique identifier
- `Name`: Owner name
- `Address`: Owner address
- `Photo`: Owner photo URL
- `Birthday`: Owner birthday

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Alexandro Munera**
- GitHub: [@AlexandroMunera](https://github.com/AlexandroMunera)

## 🙏 Acknowledgments

- Built with modern web technologies
- Inspired by real estate management needs
- Thanks to the open-source community for the amazing tools and libraries

---

**Happy coding!** 🎉