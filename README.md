# Automotive Intelligent Operating System (AIOS)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![MongoDB](https://img.shields.io/badge/MongoDB-3.5.2-47A248?style=flat-square&logo=mongodb)](https://www.mongodb.com/)
[![OpenAI](https://img.shields.io/badge/OpenAI-2.7.0-412991?style=flat-square&logo=openai)](https://openai.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](LICENSE)


AIOS is a comprehensive, AI-enhanced dealership management platform built on ASP.NET Core MVC. It integrates OpenAI's language models to provide intelligent pricing recommendations, automated loan approvals, sales training simulations, and trade-in valuations.

---

## Features

### 🤖 AI-Powered Modules

| Module | Description |
|--------|-------------|
| **AI Pricing Engine** | Intelligent vehicle pricing recommendations based on market analysis |
| **Loan Approval AI** | Automated loan pre-approval decisions using AI assessment |
| **Sales Training Simulator** | Interactive AI-driven sales scenario training |
| **Trade-In Valuator** | AI-powered vehicle trade-in value estimation |

### 📊 Core Management Features

- **Customer Relationship Management (CRM)** - Full customer lifecycle management
- **Vehicle Inventory Management** - Track and manage dealership inventory
- **Appointment Scheduling** - Service and sales appointment coordination
- **Finance Calculator** - Loan payment and financing calculations
- **Newsletter Management** - Customer communication and marketing
- **Service Department** - Service scheduling and tracking

---

## User Interface

<table>
  <tr>
    <th>Newsletter</th>
    <th>Customer Management</th>
    <th>Trade-In Value Estimator</th>
  </tr>
  <tr>
    <td align="center"><img src="./screenshots/newsletter.png" width="250"/></td>
    <td align="center"><img src="./screenshots/customers.png" width="250"/></td>
    <td align="center"><img src="./screenshots/trade-in-value.png" width="250"/></td>
  </tr>
  <tr>
    <th colspan="2">Appointment Calendar & Management</th>
    <th>Loan Approval Results</th>
  </tr>
  <tr>
    <td align="center"><img src="./screenshots/calender.png" width="250"/><br/>Calendar View</td>
    <td align="center"><img src="./screenshots/edit-appointment.png" width="250"/><br/>Editing Appointment</td>
    <td align="center"><img src="./screenshots/loan-results.png" width="250"/></td>
  </tr>
  <tr>
    <th>Vehicle Inventory</th>
    <th>Adding New Vehicle</th>
    <th colspan="1">AI Sales Training Simulator</th>
  </tr>
  <tr>
    <td align="center"><img src="./screenshots/inventory.png" width="250"/></td>
    <td align="center"><img src="./screenshots/adding-inventory.png" width="250"/></td>
    <td align="center"><img src="./screenshots/training-sim.png" width="250"/><br/>Simulator<br/><img src="./screenshots/training-sim-results.png" width="250"/><br/>Results</td>
  </tr>
</table>

---

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Architecture Overview](#architecture-overview)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [API Reference](#api-reference)
- [Database Schema](#database-schema)
- [Dependency Injection Configuration](#dependency-injection-configuration)
- [CORS Configuration](#cors-configuration)
- [Contributing](#contributing)
- [License](#license)
- [Project Link](#project-link)

---

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              CLIENT LAYER                                    │
│                    (MVC Views / Razor Pages / REST API)                     │
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
                                      ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                           CONTROLLER LAYER                                   │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐│
│  │   MVC       │ │   API       │ │   AI        │ │   Service               ││
│  │ Controllers │ │ Controllers │ │ Controllers │ │   Controllers           ││
│  └─────────────┘ └─────────────┘ └─────────────┘ └─────────────────────────┘│
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
                                      ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                          REPOSITORY LAYER                                    │
│  ┌──────────────────┐ ┌──────────────────┐ ┌──────────────────────────────┐ │
│  │ CustomerRepo     │ │ VehicleRepo      │ │ AppointmentRepo              │ │
│  │ NewsletterRepo   │ │ AiPricingRepo    │ │ LoanApprovalRepo             │ │
│  │ SalesTrainingRepo│ │                  │ │                              │ │
│  └──────────────────┘ └──────────────────┘ └──────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
                    ┌─────────────────┴─────────────────┐
                    ▼                                   ▼
┌───────────────────────────────┐     ┌───────────────────────────────────────┐
│         MongoDB               │     │           OpenAI API                  │
│    (Document Database)        │     │   (GPT Models for AI Features)        │
└───────────────────────────────┘     └───────────────────────────────────────┘
```

---

## Technology Stack

| Layer | Technology | Version | Purpose |
|-------|------------|---------|---------|
| **Runtime** | .NET | 8.0 | Cross-platform application framework |
| **Web Framework** | ASP.NET Core MVC | 8.0 | Model-View-Controller web architecture |
| **Database** | MongoDB | 3.5.2 (Driver) | NoSQL document storage |
| **AI Integration** | OpenAI SDK | 2.7.0 | GPT model integration for AI features |
| **Frontend** | Razor Views | - | Server-side rendered HTML |
| **Validation** | jQuery Validation | - | Client-side form validation |
| **Serialization** | System.Text.Json | - | JSON serialization with camelCase policy |

---

## Features

### 🤖 AI-Powered Modules

| Module | Description | Endpoint |
|--------|-------------|----------|
| **AI Pricing Engine** | Intelligent vehicle pricing recommendations based on market analysis | `/api/ai-pricing` |
| **Loan Approval AI** | Automated loan pre-approval decisions using AI assessment | `/api/loan-approval` |
| **Sales Training Simulator** | Interactive AI-driven sales scenario training | `/api/sales-training` |
| **Trade-In Valuator** | AI-powered vehicle trade-in value estimation | `/api/trade-in` |

### 📊 Core Management Features

- **Customer Relationship Management (CRM)** - Full customer lifecycle management
- **Vehicle Inventory Management** - Track and manage dealership inventory
- **Appointment Scheduling** - Service and sales appointment coordination
- **Finance Calculator** - Loan payment and financing calculations
- **Newsletter Management** - Customer communication and marketing
- **Service Department** - Service scheduling and tracking

---

## Project Structure

```
AIOS/
├── Controllers/
│   ├── AiPricingController.cs        # AI pricing recommendations
│   ├── AiTradeInController.cs        # Trade-in value estimation
│   ├── AppointmentsApiEndpoints.cs   # Appointment REST API
│   ├── CustomerApiController.cs      # Customer REST API
│   ├── CustomersController.cs        # Customer MVC views
│   ├── FinanceController.cs          # Finance calculations
│   ├── HomeController.cs             # Main dashboard
│   ├── InventoryController.cs        # Vehicle inventory management
│   ├── LoanApprovalAIController.cs   # AI loan approval processing
│   ├── NewsletterController.cs       # Newsletter management
│   ├── PricingController.cs          # Pricing management views
│   ├── SalesController.cs            # Sales management
│   ├── SalesTrainingAIController.cs  # AI sales training simulator
│   ├── ServiceController.cs          # Service department
│   └── TrainingController.cs         # Training module views
│
├── Models/
│   ├── Appointments.cs               # Appointment entity
│   ├── Customer.cs                   # Customer entity
│   ├── FinanceCalculation.cs         # Finance calculation model
│   ├── LoanApprovalRequest.cs        # Loan approval request DTO
│   ├── MongoDbSettings.cs            # MongoDB configuration POCO
│   ├── NewsLetter.cs                 # Newsletter subscriber entity
│   ├── SalesTrainingRequest.cs       # Sales training request DTO
│   ├── TradeInRequest.cs             # Trade-in valuation request DTO
│   ├── Vehicle.cs                    # Vehicle inventory entity
│   └── VehiclePricingRequest.cs      # Pricing request DTO
│
├── Repositories/
│   ├── AiPricingRepository.cs        # AI pricing data access
│   ├── AppointmentRepository.cs      # Appointment CRUD operations
│   ├── CustomerRepository.cs         # Customer CRUD operations
│   ├── LoanApprovalRepository.cs     # Loan approval data access
│   ├── NewsletterRepository.cs       # Newsletter CRUD operations
│   ├── SalesTrainingRepository.cs    # Sales training data access
│   └── VehicleRepository.cs          # Vehicle CRUD operations
│
├── Views/
│   ├── Customers/                    # Customer management views
│   ├── Finance/                      # Finance calculator views
│   ├── Home/                         # Dashboard and landing pages
│   ├── Inventory/                    # Inventory management views
│   ├── Pricing/                      # Pricing tool views
│   ├── Sales/                        # Sales management views
│   ├── Service/                      # Service department views
│   ├── Shared/                       # Layout and partial views
│   └── Training/                     # Training module views
│
├── Properties/
│   └── launchSettings.json           # Development launch configuration
│
├── wwwroot/                          # Static assets (CSS, JS, images)
├── appsettings.json                  # Application configuration
├── appsettings.Development.json      # Development-specific config
├── Program.cs                        # Application entry point & DI setup
└── AIOS.csproj                       # Project file
```

---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [MongoDB](https://www.mongodb.com/try/download/community) (local) or [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (cloud)
- [OpenAI API Key](https://platform.openai.com/api-keys) for AI features
- Visual Studio 2022+ or VS Code with C# extension

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/medo-com/Automotive-Intelligent-Operating-System.git
   cd Automotive-Intelligent-Operating-System
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Configure the application** (see [Configuration](#configuration))

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**
   - HTTP: `http://localhost:5219`
   - HTTPS: `https://localhost:7123`

### Configuration

1. **Copy the template configuration file:**
   ```bash
   cp appsettings.template.json appsettings.json
   ```

2. **Update `appsettings.json` with your credentials:**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "MongoDbSettings": {
    "ConnectionString": "mongodb+srv://<username>:<password>@<cluster>.mongodb.net/?appName=AIOS",
    "DatabaseName": "CustomerDB",
    "CustomersCollectionName": "Customers",
    "VehiclesCollectionName": "Vehicles"
  },
  "OpenAI": {
    "ApiKey": "<your-openai-api-key>"
  }
}
```

#### Environment Variables (Recommended for Production)

```bash
export MongoDbSettings__ConnectionString="mongodb+srv://user:pass@cluster.mongodb.net/AIOS"
export OpenAI__ApiKey="sk-your-api-key"
```

---

## API Reference

### Customer API

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/customers` | Retrieve all customers |
| `GET` | `/api/customers/{id}` | Retrieve customer by ID |
| `POST` | `/api/customers` | Create new customer |
| `PUT` | `/api/customers/{id}` | Update existing customer |
| `DELETE` | `/api/customers/{id}` | Delete customer |

### Appointments API

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/appointments` | Retrieve all appointments |
| `POST` | `/api/appointments` | Schedule new appointment |
| `PUT` | `/api/appointments/{id}` | Update appointment |
| `DELETE` | `/api/appointments/{id}` | Cancel appointment |

### AI Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/ai-pricing/analyze` | Get AI pricing recommendation |
| `POST` | `/api/loan-approval/evaluate` | AI loan pre-approval |
| `POST` | `/api/sales-training/simulate` | Start training simulation |
| `POST` | `/api/trade-in/estimate` | Get trade-in value estimate |

---

## Database Schema

### Collections

#### `customers`
```javascript
{
  "_id": ObjectId,
  "firstName": String,
  "lastName": String,
  "email": String,
  "phone": String,
  "address": String,
  "createdAt": DateTime,
  "updatedAt": DateTime
}
```

#### `vehicles`
```javascript
{
  "_id": ObjectId,
  "vin": String,
  "make": String,
  "model": String,
  "year": Number,
  "price": Decimal,
  "mileage": Number,
  "condition": String,
  "status": String  // "Available", "Sold", "Reserved"
}
```

#### `appointments`
```javascript
{
  "_id": ObjectId,
  "customerId": ObjectId,
  "type": String,  // "Service", "Sales", "TestDrive"
  "scheduledDate": DateTime,
  "notes": String,
  "status": String
}
```

---

## User Interface

### Newsletter
![Newsletter](./screenshots/newsletter.png)

### Appointment Calendar & Management
| Calendar View | Editing Appointment |
|:-------------:|:-------------------:|
| ![Calendar](./screenshots/calender.png) | ![Editing Appointment](./screenshots/edit-appointment.png) |

### Vehicle Inventory
| Inventory List | Adding New Vehicle |
|:--------------:|:------------------:|
| ![Vehicle Inventory](./screenshots/inventory.png) | ![Adding Inventory](./screenshots/adding-inventory.png) |

### Customer Management
![Customers](./screenshots/customers.png)

### AI Trade-In Value Estimator
![Trade-In Value Estimator](./screenshots/trade-in-value.png)

### AI Loan Approval
![Loan Approval Results](./screenshots/loan-results.png)

### AI Sales Training Simulator
| Training Simulator | Training Results |
|:------------------:|:----------------:|
| ![Training Simulator](./screenshots/training-sim.png) | ![Training Simulator Results](./screenshots/training-sim-results.png) |

---

## Dependency Injection Configuration

The application uses the built-in ASP.NET Core DI container with the following service lifetimes:

| Service | Lifetime | Rationale |
|---------|----------|-----------|
| `SalesTrainingRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `NewsletterRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `CustomerRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `AppointmentRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `VehicleRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `AiPricingRepository` | Singleton | Stateless, thread-safe MongoDB operations |
| `LoanApprovalRepository` | Scoped | Request-specific state for loan processing |

---

## CORS Configuration

The application is configured with an open CORS policy for development:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

> ⚠️ **Production Warning**: Restrict CORS origins in production environments.

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Project Link:** [https://github.com/medo-com/Automotive-Intelligent-Operating-System](https://github.com/medo-com/Automotive-Intelligent-Operating-System)