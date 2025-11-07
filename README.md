# 🏦 BankingApp - Personal Banking Management System

A modern, secure personal banking application built with **Blazor WebAssembly** and **.NET 8.0**. This application provides a complete banking experience with account management, transaction tracking, interest calculations, and data backup functionality.

![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)

## 🌟 Features

### 🔐 Security
- **PIN-based Authentication**: 4-digit PIN system with SHA256 hashing
- **Session Management**: Secure login/logout functionality
- **Route Protection**: All banking pages require authentication

### 💳 Account Management
- **Multiple Account Types**: 
  - Lönekonto (Salary Account)
  - Sparkonto (Savings Account) with interest calculation
- **Multi-Currency Support**: SEK, EUR, USD
- **Real-time Balance Updates**: Instant balance calculations

### 💰 Transaction System
- **Deposit & Withdrawal**: Easy money management
- **Fund Transfers**: Transfer between your accounts
- **Transaction History**: Complete audit trail with filtering
- **Transaction Categories**: Organized transaction types

### 📈 Interest Calculation
- **Automatic Interest**: 2.5% annual interest for savings accounts
- **Compound Daily Interest**: Professional banking calculations
- **Interest History**: Track all interest payments
- **Bulk Processing**: Apply interest to all savings accounts

### 💾 Data Management
- **Export/Import**: Complete data backup as JSON files
- **Local Storage**: Persistent data storage in browser
- **Data Statistics**: Real-time overview of accounts and transactions
- **Data Validation**: Error handling for import operations

### 🎨 User Interface
- **Responsive Design**: Works on desktop and mobile
- **Swedish Language**: Complete Swedish localization
- **Bootstrap UI**: Modern, professional interface
- **Real-time Updates**: Dynamic UI updates without page refresh

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Modern web browser (Chrome, Firefox, Edge, Safari)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/AdamWalid-hustler/BankingApp.git
   cd BankingApp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

## 📱 Usage Guide

### First Time Setup
1. **Launch the application** in your web browser
2. **Set up your PIN** - Create a 4-digit PIN for security
3. **Create your first account** - Choose account type and currency
4. **Start banking** - Make deposits, withdrawals, and transfers

### Daily Banking Operations

#### 🏠 **Dashboard/Accounts Page**
- View all your accounts with balances
- Create new accounts (Lönekonto or Sparkonto)
- Apply interest to savings accounts
- Monitor interest rates and calculation dates

#### 💸 **New Transaction Page**
- Make deposits to any account
- Withdraw money from accounts
- Transfer funds between accounts
- All transactions are logged automatically

#### 📊 **Transaction History**
- View complete transaction history
- Filter by date range and transaction type
- Sort transactions by various criteria
- Track all deposits, withdrawals, transfers, and interest

#### � **Export/Import Data**
- **Export**: Download all your data as a JSON backup file
- **Import**: Restore data from a previous backup
- **Statistics**: View account and transaction summaries
- **Data Safety**: Warning system for data operations

## 🏗️ Project Structure

```
BankingApp/
├── 📁 Components/              # Reusable UI components
│   ├── AuthenticationRequired.razor
│   └── PinEntry.razor
├── 📁 Layout/                  # Application layout
│   ├── MainLayout.razor
│   └── NavMenu.razor
├── 📁 Models/                  # Data models
│   ├── BankAccount.cs
│   └── Transaction.cs
├── 📁 Pages/                   # Application pages
│   ├── Accounts.razor
│   ├── ExportImport.razor
│   ├── History.razor
│   ├── Home.razor
│   └── NewTransaction.razor
├── 📁 Services/                # Business logic
│   ├── AccountService.cs
│   ├── AuthenticationService.cs
│   ├── IAccountService.cs
│   ├── IAuthenticationService.cs
│   ├── IStorageService.cs
│   ├── LocalStorageService.cs
│   └── PinService.cs
├── 📁 wwwroot/                 # Static files
│   ├── css/
│   └── index.html
├── App.razor                   # Main app component
├── Program.cs                  # Application startup
└── BankingApp.csproj          # Project file
```

## 🔧 Technology Stack

- **Framework**: Blazor WebAssembly (.NET 8.0)
- **Language**: C#
- **UI Framework**: Bootstrap 5
- **Storage**: Browser Local Storage
- **Authentication**: Custom PIN-based system
- **Serialization**: System.Text.Json
- **Architecture**: Component-based with Dependency Injection

## 🎯 Core Components

### Models
- **BankAccount**: Account data with interest calculation
- **Transaction**: Transaction records with balance tracking

### Services
- **AccountService**: Core banking operations
- **AuthenticationService**: Security and session management
- **LocalStorageService**: Data persistence
- **PinService**: PIN hashing and validation

### Components
- **AuthenticationRequired**: Route protection wrapper
- **PinEntry**: PIN input interface

## 💡 Key Features Explained

### Interest Calculation
Savings accounts (Sparkonto) automatically earn 2.5% annual interest:
- **Formula**: `newBalance = balance × (1 + annualRate/365)^days`
- **Compounding**: Daily compound interest
- **Tracking**: Last calculation date stored
- **Automation**: Bulk interest application available

### Data Persistence
All data is stored locally in your browser:
- **Accounts**: Complete account information
- **Transactions**: Full transaction history
- **Settings**: PIN and authentication state
- **Export**: Backup to JSON files
- **Import**: Restore from backup files

### Security Features
- **PIN Protection**: 4-digit PIN with SHA256 hashing
- **Session Management**: Automatic logout capability
- **Route Guards**: Protected banking pages
- **Data Validation**: Input validation and error handling

## 🔒 Security Considerations

⚠️ **Important**: This is a demo application for educational purposes:
- Data is stored locally in browser storage
- PIN hashing uses SHA256 (use stronger hashing in production)
- No server-side validation or encryption
- Not suitable for real financial data

## � Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📋 TODO / Future Enhancements

- [ ] Multi-user support with user accounts
- [ ] Server-side API with database storage
- [ ] Enhanced security with JWT tokens
- [ ] Transaction categories and budgeting
- [ ] Scheduled transfers and recurring payments
- [ ] Account statements and PDF reports
- [ ] Mobile app with Xamarin or MAUI
- [ ] Dark mode theme support
- [ ] Multi-language support (English, etc.)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Adam Walid**
- GitHub: [@AdamWalid-hustler](https://github.com/AdamWalid-hustler)

## 🙏 Acknowledgments

- Built with [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- UI components from [Bootstrap](https://getbootstrap.com/)
- Icons from [Open Iconic](https://useiconic.com/open)

---

## 📞 Support

If you encounter any issues or have questions:
1. Check the [Issues](https://github.com/AdamWalid-hustler/BankingApp/issues) page
2. Create a new issue with detailed description
3. Include browser information and steps to reproduce

---

**⭐ If you found this project helpful, please give it a star!**