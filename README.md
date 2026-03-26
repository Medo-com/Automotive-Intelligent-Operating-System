# Automotive Intelligent Operating System (AIOS)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![MongoDB](https://img.shields.io/badge/MongoDB-3.5.2-47A248?style=flat-square&logo=mongodb)](https://www.mongodb.com/)
[![OpenAI](https://img.shields.io/badge/OpenAI-2.7.0-412991?style=flat-square&logo=openai)](https://openai.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](LICENSE)

AIOS is a comprehensive, AI-enhanced automotive dealership management platform. It integrates OpenAI's language models to deliver intelligent pricing recommendations, automated loan approvals, interactive sales training simulations, and real-time trade-in valuations — all within a single unified system.

---

## Features

### 🤖 AI-Powered Modules

| Module | Description |
|--------|-------------|
| **AI Pricing Engine** | Intelligent vehicle pricing recommendations based on market analysis |
| **Loan Approval AI** | Automated loan pre-approval decisions using AI-driven risk assessment |
| **Sales Training Simulator** | Interactive, AI-driven sales scenario training for staff development |
| **Trade-In Valuator** | AI-powered vehicle trade-in value estimation in real time |

### 📊 Dealership Management

| Feature | Description |
|---------|-------------|
| **Customer CRM** | Full customer lifecycle management — create, edit, track, and communicate |
| **Vehicle Inventory** | Add, update, and browse dealership vehicle stock |
| **Appointment Scheduling** | Coordinate service, sales, and test-drive appointments via calendar |
| **Finance Calculator** | Loan payment and financing scenario calculations |
| **Newsletter** | Customer outreach and marketing communication tools |
| **Service Department** | Service scheduling, tracking, and management |

---

## User Interface

<table>
  <tr>
    <td align="center"><b>Newsletter</b><br/><br/><img src="./screenshots/newsletter.png" width="280"/></td>
    <td align="center"><b>Customer Management</b><br/><br/><img src="./screenshots/customers.png" width="280"/></td>
  </tr>
  <tr>
    <td align="center"><b>Calendar View</b><br/><br/><img src="./screenshots/calender.png" width="280"/></td>
    <td align="center"><b>Editing Appointment</b><br/><br/><img src="./screenshots/edit-appointment.png" width="280"/></td>
  </tr>
  <tr>
    <td align="center"><b>Vehicle Inventory</b><br/><br/><img src="./screenshots/inventory.png" width="280"/></td>
    <td align="center"><b>Adding New Vehicle</b><br/><br/><img src="./screenshots/adding-inventory.png" width="280"/></td>
  </tr>
  <tr>
    <td align="center"><b>AI Trade-In Value Estimator</b><br/><br/><img src="./screenshots/trade-in-value.png" width="280"/></td>
    <td align="center"><b>AI Loan Approval Results</b><br/><br/><img src="./screenshots/loan-results.png" width="280"/></td>
  </tr>
  <tr>
    <td align="center"><b>AI Sales Training Simulator</b><br/><br/><img src="./screenshots/training-sim.png" width="280"/></td>
    <td align="center"><b>Training Simulator Results</b><br/><br/><img src="./screenshots/training-sim-results.png" width="280"/></td>
  </tr>
</table>

---

## Technical Documentation

<details>
<summary><b>📖 Table of Contents</b></summary>

- [Getting Started](#getting-started)
- [Architecture Overview](#architecture-overview)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [API Reference](#api-reference)
- [Database Schema](#database-schema)
- [Dependency Injection](#dependency-injection)
- [CORS Configuration](#cors-configuration)
- [Contributing](#contributing)
- [License](#license)

</details>

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

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Copy and configure settings**
   ```bash
   cp appsettings.template.json appsettings.json
   ```

4. **Update `appsettings.json` with your credentials:**
   ```json
   {
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

   > ⚠️ `appsettings.json` is excluded from version control via `.gitignore`. Never commit credentials.

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   | Protocol | URL |
   |----------|-----|
   | HTTP | `http://localhost:5219` |
   | HTTPS | `https://localhost:7123` |

---

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              CLIENT LAYER                                   │
│                    (MVC Views / Razor Pages / REST API)                     │
└────────────────────────────────────┬────────────────────────────────────────┘
                                     ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                           CONTROLLER LAYER                                  │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ ┌───────────────────────┐ │
│  │   MVC       │ │   API       │ │   AI        │ │   Service             │ │
│  │ Controllers │ │ Controllers │ │ Controllers │ │   Controllers         │ │
│  └─────────────┘ └─────────────┘ └─────────────┘ └───────────────────────┘ │
└────────────────────────────────────┬────────────────────────────────────────┘
                                     ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                          REPOSITORY LAYER                                   │
│  ┌──────────────────┐ ┌──────────────────┐ ┌────────────────────────────┐  │
│  │ CustomerRepo     │ │ VehicleRepo      │ │ AppointmentRepo            │  │
│  │ NewsletterRepo   │ │ AiPricingRepo    │ │ LoanApprovalRepo           │  │
│  │ SalesTrainingRepo│ │                  │ │                            │  │
│  └──────────────────┘ └──────────────────┘ └────────────────────────────┘  │
└────────────────────────────┬──────────────────────┬─────────────────────────┘
                             ▼                      ▼
              ┌──────────────────────┐  ┌──────────────────────────┐
              │       MongoDB        │  │       OpenAI API         │
              │  (Document Database) │  │  (GPT Language Models)   │
              └──────────────────────┘  └──────────────────────────┘
```

---

## Technology Stack

| Layer | Technology | Version | Purpose |
|-------|------------|---------|---------|
| **Runtime** | .NET | 8.0 | Cross-platform application framework |
| **Web Framework** | ASP.NET Core MVC | 8.0 | Model-View-Controller web architecture |
| **Database** | MongoDB | 3.5.2 (Driver) | NoSQL document storage |
| **AI Integration** | OpenAI SDK | 2.7.0 | GPT model integration for AI features |
| **Frontend** | Razor Views | — | Server-side rendered HTML |
| **Validation** | jQuery Validation | — | Client-side form validation |
| **Serialization** | System.Text.Json | — | camelCase JSON serialization |

---

## Project Structure

```
AIOS/
├── Controllers/
│   ├── AiPricingController.cs         # AI pricing recommendations
│   ├── AiTradeInController.cs         # Trade-in value estimation
│   ├── AppointmentsApiEndpoints.cs    # Appointment REST API
│   ├── CustomerApiController.cs       # Customer REST API
│   ├── CustomersController.cs         # Customer MVC views
│   ├── FinanceController.cs           # Finance calculations
│   ├── HomeController.cs              # Main dashboard
│   ├── InventoryController.cs         # Vehicle inventory management
│   ├── LoanApprovalAIController.cs    # AI loan approval processing
│   ├── NewsletterController.cs        # Newsletter management
│   ├── PricingController.cs           # Pricing management views
│   ├── SalesController.cs             # Sales management
│   ├── SalesTrainingAIController.cs   # AI sales training simulator
│   ├── ServiceController.cs           # Service department
│   └── TrainingController.cs          # Training module views
├── Models/
│   ├── Appointments.cs                # Appointment entity
│   ├── Customer.cs                    # Customer entity
│   ├── FinanceCalculation.cs          # Finance calculation model
│   ├── LoanApprovalRequest.cs         # Loan approval request DTO
│   ├── MongoDbSettings.cs             # MongoDB configuration POCO
│   ├── NewsLetter.cs                  # Newsletter subscriber entity
│   ├── SalesTrainingRequest.cs        # Sales training request DTO
│   ├── TradeInRequest.cs              # Trade-in valuation request DTO
│   ├── Vehicle.cs                     # Vehicle inventory entity
│   └── VehiclePricingRequest.cs       # Pricing request DTO
├── Repositories/
│   ├── AiPricingRepository.cs         # AI pricing data access
│   ├── AppointmentRepository.cs       # Appointment CRUD operations
│   ├── CustomerRepository.cs          # Customer CRUD operations
│   ├── LoanApprovalRepository.cs      # Loan approval data access
│   ├── NewsletterRepository.cs        # Newsletter CRUD operations
│   ├── SalesTrainingRepository.cs     # Sales training data access
│   └── VehicleRepository.cs           # Vehicle CRUD operations
├── Views/
│   ├── Customers/                     # Customer management views
│   ├── Finance/                       # Finance calculator views
│   ├── Home/                          # Dashboard and landing pages
│   ├── Inventory/                     # Inventory management views
│   ├── Pricing/                       # Pricing tool views
│   ├── Sales/                         # Sales management views
│   ├── Service/                       # Service department views
│   ├── Shared/                        # Layout and partial views
│   └── Training/                      # Training module views
├── Properties/
│   └── launchSettings.json            # Development launch configuration
├── wwwroot/                           # Static assets (CSS, JS, images)
├── appsettings.template.json          # Configuration template (safe to commit)
├── Program.cs                         # Application entry point & DI setup
└── AIOS.csproj                        # Project file
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
  "type": String,       // "Service", "Sales", "TestDrive"
  "scheduledDate": DateTime,
  "notes": String,
  "status": String
}
```

---

## Dependency Injection

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

Development mode uses an open policy. **Restrict origins in production.**

```csharp
policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
```

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

---

<p align="center">
  <a href="https://github.com/medo-com/Automotive-Intelligent-Operating-System">
    <b>github.com/medo-com/Automotive-Intelligent-Operating-System</b>
  </a>
</p>