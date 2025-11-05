using System;

namespace BankingApp.Services
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        event EventHandler<bool> AuthenticationChanged;
        void SetAuthenticated(bool isAuthenticated);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private bool _isAuthenticated = false;

        public bool IsAuthenticated => _isAuthenticated;

        public event EventHandler<bool>? AuthenticationChanged;

        public void SetAuthenticated(bool isAuthenticated)
        {
            if (_isAuthenticated != isAuthenticated)
            {
                _isAuthenticated = isAuthenticated;
                AuthenticationChanged?.Invoke(this, isAuthenticated);
            }
        }
    }
}