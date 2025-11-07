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
- **⚡ Testing Mode**: Accelerated interest calculation (5 seconds = 1 day) for development

### 💾 Data Management
- **Export/Import**: Complete data backup as JSON files
- **Local Storage**: Persistent data storage in browser
- **Data Statistics**: Real-time overview of accounts and transactions
- **Data Validation**: Error handling for import operations

### 🎨 User Interface
- **Enhanced Icons**: Intuitive navigation with emojis and Open Iconic icons
- **Responsive Design**: Works on desktop and mobile
- **Swedish Language**: Complete Swedish localization
- **Bootstrap UI**: Modern, professional interface
- **Real-time Updates**: Dynamic UI updates without page refresh
- **Visual Feedback**: Loading states, success/error messages, and progress indicators

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
#### 🏠 **Dashboard/Accounts Page** (Main Page)
- View all your accounts with balances and interest rates
- Create new accounts (Lönekonto or Sparkonto)
- Apply interest to savings accounts individually or in bulk
- Monitor interest rates and calculation dates with real-time updates
- **⚡ Testing Mode Indicator**: Shows accelerated interest calculation status

#### 💸 **New Transaction Page**
- Make deposits to any account
- Withdraw money from accounts
- Transfer funds between accounts
- All transactions are logged automatically with timestamps

#### 📊 **Transaction History**
- View complete transaction history with enhanced filtering
- Filter by date range and transaction type
- Sort transactions by various criteria
- Track all deposits, withdrawals, transfers, and interest payments

#### 💾 **Export/Import Data**
- **Export**: Download all your data as a JSON backup file with timestamps
- **Import**: Restore data from a previous backup with validation
- **Statistics**: Real-time overview of account and transaction summaries
- **Data Safety**: Warning system and error handling for data operations

### 🎯 Enhanced Navigation
The application features an intuitive navigation system with:
- **🏦 Brand**: Enhanced app branding with banking icon
- **🏠 Konton**: Main dashboard (accounts overview)
- **💸 Ny transaktion**: Create new transactions
- **📊 Transaktions Historik**: View transaction history
- **💾 Export/Import**: Data backup and restore
- **🔓 Logout**: Secure session termination

### ⚡ Testing Features
For development and demonstration purposes:
- **Accelerated Interest**: 5-second intervals instead of daily calculations
- **Real-time Updates**: Automatic page refresh to show interest accumulation
- **Visual Indicators**: Clear testing mode warnings and status displays

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
- **Tracking**: Last calculation date and time stored
- **Automation**: Bulk interest application available
- **⚡ Testing Mode**: Accelerated calculation (5 seconds = 1 virtual day)

### Enhanced User Experience
- **Intuitive Navigation**: Clear icons and emojis for each section
- **Real-time Updates**: Live balance and transaction updates
- **Visual Feedback**: Success/error messages, loading states
- **Responsive Design**: Optimal viewing on all devices
- **Swedish Localization**: Complete Swedish language interface

### Data Persistence
All data is stored locally in your browser:
- **Accounts**: Complete account information with interest tracking
- **Transactions**: Full transaction history with timestamps
- **Settings**: PIN and authentication state
- **Export**: Timestamped backup to JSON files
- **Import**: Validated restore from backup files

### Security Features
- **PIN Protection**: 4-digit PIN with SHA256 hashing
- **Session Management**: Automatic logout capability
- **Route Guards**: Protected banking pages
- **Data Validation**: Comprehensive input validation and error handling

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
- [ ] Advanced interest calculation options
- [ ] Account performance analytics and charts

## 🆕 Recent Updates

### Version 2.0 Features
- **✅ Enhanced Navigation**: Intuitive icons with emojis for better UX
- **✅ Testing Mode**: Accelerated interest calculation for development
- **✅ Real-time Updates**: Live page refresh for immediate feedback
- **✅ Visual Improvements**: Enhanced branding and professional icons
- **✅ Better Feedback**: Comprehensive status messages and indicators

### Version 1.0 Features
- ✅ Complete banking functionality (accounts, transactions, history)
- ✅ PIN-based security system
- ✅ Interest calculation for savings accounts
- ✅ Export/Import data functionality
- ✅ Responsive Swedish interface

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

<<<<<<< HEAD
**⭐ If you found this project helpful, please give it a star!**
=======
## 🧠 Architecture Overview



---

## ⚙️ Technologies Used
- **.NET 8 Blazor WebAssembly**
- **C#**
- **Bootstrap 5**
- **LocalStorage (via IJSRuntime)**
- **JSON Serialization (System.Text.Json)**

---

## 🧪 How to Run

1. Clone the repository:
   bash
   git clone [https://github.com/](https://github.com/AdamWalid-hustler/BankingApp)



>>>>>>> 3bfe6768876ebd4fd47acafa1888e79574a3bbf1
