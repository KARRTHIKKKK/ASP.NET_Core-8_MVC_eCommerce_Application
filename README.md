# 🛒 ASP.NET Core 8 MVC eCommerce Application

[![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-green.svg)](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208-orange.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Latest-red.svg)](https://www.microsoft.com/en-us/sql-server)

## 📋 Table of Contents
- [Overview](#overview)
- [Demo Video](#demo-video)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Solution Architecture](#solution-architecture)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

## 🔷 Overview

A **modular, full-stack eCommerce web application** built using **ASP.NET Core 8 MVC** following industry best practices with clean architecture, Identity-based authentication, and Entity Framework Core integration. This application demonstrates modern web development patterns including repository pattern, dependency injection, and area-based feature organization.

## 🎥 Demo Video

### YouTube Link
- [📺 Watch on YouTube](https://www.youtube.com/watch?v=7XIx_slTZ2g)

## ✨ Features

### 🛍️ Core eCommerce Functionality
- **Product Catalog** - Browse and search products
- **Shopping Cart** - Add, remove, and manage cart items
- **User Authentication** - Register, login, and user management
- **Invoice Generation** - Order processing and invoice creation
- **Responsive Design** - Mobile-friendly Bootstrap UI

### 🏗️ Technical Features
- **Modular Architecture** - Area-based feature separation
- **Repository Pattern** - Clean data access layer
- **Code-First Migrations** - Database schema management
- **Identity Integration** - Secure user authentication
- **Strongly-Typed Views** - ViewModels for data binding

## 🔨 Technologies Used

| Category | Technology |
|----------|------------|
| **Framework** | ASP.NET Core 8 MVC |
| **ORM** | Entity Framework Core 8 |
| **Database** | SQL Server |
| **Authentication** | ASP.NET Core Identity |
| **Frontend** | Bootstrap, Razor Views, HTML5, CSS3, JavaScript |
| **Architecture** | Repository Pattern, Dependency Injection |
| **Development** | Visual Studio, Code-First Migrations |

## 🏛️ Solution Architecture

```
Sandhata.eCommerce.Solution/
├── 📁 Sandhata.eCommerce.Models/          # Data Models & ViewModels
├── 📁 Sandhata.eCommerce.Repositories/    # Data Access Layer
└── 📁 Sandhata.eCommerce.Mvc.UI/          # MVC Web Application
```

### **1. Sandhata.eCommerce.Models**
- **Data Models**: `Product`, `Cart`, `Customer`, `Invoice`
- **ViewModels**: `YourCartVM` for composite view rendering
- **DTOs**: Data transfer objects for API communication

### **2. Sandhata.eCommerce.Repositories**
- **Repository Interfaces**: `ICartRepository`, `ICommonRepository`
- **Implementation**: Concrete repository classes
- **Database Context**: `SandhataDbContext` with EF Core
- **Migrations**: Code-first database schema management

### **3. Sandhata.eCommerce.Mvc.UI**
- **Areas**: Feature-based organization (`Carts`, `Products`, `Invoices`)
- **Controllers**: MVC controllers for each feature area
- **Views**: Razor views with shared layouts
- **Static Content**: CSS, JavaScript, images in `wwwroot`

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (LocalDB, Express, or Full)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 📦 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/sandhata-ecommerce.git
   cd sandhata-ecommerce
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Edit `appsettings.json` in the `Sandhata.eCommerce.Mvc.UI` project:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SandhataECommerceDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Run database migrations**
   ```bash
   cd Sandhata.eCommerce.Mvc.UI
   dotnet ef database update
   ```

5. **Build and run the application**
   ```bash
   dotnet build
   dotnet run
   ```

6. **Access the application**
   - Open browser and navigate to `https://localhost:5001`

## ⚙️ Configuration

### Database Configuration
The application uses **Entity Framework Core** with **Code-First** approach:

```csharp
// SandhataDbContext.cs
public class SandhataDbContext : IdentityDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}
```

### Identity Configuration
ASP.NET Core Identity is configured for user authentication:
- User registration and login
- Role-based authorization
- Secure password policies

## 📱 Usage

### For Users
1. **Register/Login** - Create account or sign in
2. **Browse Products** - View product catalog
3. **Add to Cart** - Select items and quantities
4. **Checkout** - Review cart and complete purchase
5. **View Invoices** - Access order history

### For Developers
- **Adding New Features**: Create new areas under `Areas/` folder
- **Database Changes**: Add migrations using `dotnet ef migrations add`
- **Custom Views**: Add Razor views in appropriate area folders

## 📁 Project Structure

```
Sandhata.eCommerce.Mvc.UI/
├── 📁 Areas/
│   ├── 📁 Carts/
│   │   ├── Controllers/
│   │   └── Views/
│   ├── 📁 Products/
│   │   ├── Controllers/
│   │   └── Views/
│   └── 📁 Invoices/
│       ├── Controllers/
│       └── Views/
├── 📁 Controllers/           # Main controllers
├── 📁 Views/
│   ├── 📁 Shared/
│   │   ├── _Layout.cshtml
│   │   └── _LoginPartial.cshtml
│   └── Home/
├── 📁 wwwroot/              # Static files
│   ├── css/
│   ├── js/
│   └── images/
├── 📁 Data/                 # Database context
├── appsettings.json
└── Program.cs
```

## 🗄️ Database Schema

### Core Tables
- **Products** - Product catalog information
- **Carts** - Shopping cart items
- **Customers** - Customer information
- **Invoices** - Order and billing data
- **AspNetUsers** - Identity user accounts

### Relationships
- Customer → Cart (One-to-Many)
- Cart → Product (Many-to-One)
- Customer → Invoice (One-to-Many)

## 📸 Screenshots

### Home Page
![Home Page](screenshots/home-page.png)

### Product Catalog
![Product Catalog](screenshots/products.png)

### Shopping Cart
![Shopping Cart](screenshots/cart.png)

### User Dashboard
![User Dashboard](screenshots/dashboard.png)

## 🔐 Security Features

- **ASP.NET Core Identity** integration
- **HTTPS** enforcement
- **CSRF** protection
- **SQL Injection** prevention via EF Core
- **XSS** protection through Razor encoding

## 🚀 Future Enhancements

- [ ] Payment gateway integration (Stripe, PayPal)
- [ ] Admin panel for product management
- [ ] Order tracking system
- [ ] Email notifications
- [ ] Product reviews and ratings
- [ ] Wishlist functionality
- [ ] Multi-language support
- [ ] API endpoints for mobile app

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Your Name**
- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [Your LinkedIn](https://linkedin.com/in/yourprofile)
- Email: your.email@example.com

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Bootstrap team for the responsive UI components
- Entity Framework team for the robust ORM
- Community contributors and tutorials

---

⭐ **If you found this project helpful, please give it a star!** ⭐

## 📞 Support

If you have any questions or need help with setup, please:
1. Check the [Issues](https://github.com/yourusername/sandhata-ecommerce/issues) page
2. Create a new issue with detailed description
3. Contact via email for urgent matters

---
*Built with ❤️ using ASP.NET Core 8*
