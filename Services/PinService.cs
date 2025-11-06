using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class PinService : IPinService
    {
        private readonly IStorageService _storageService;
        private const string PinKey = "banking_pin_hash";

        public PinService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<bool> HasPinAsync()
        {
            var pinHash = await _storageService.GetDataAsync<string>(PinKey);
            return !string.IsNullOrEmpty(pinHash);
        }

        public async Task SetPinAsync(string pin)
        {
            if (string.IsNullOrEmpty(pin) || pin.Length != 4 || !pin.All(char.IsDigit))
            {
                throw new ArgumentException("PIN must be exactly 4 digits");
            }

            var hash = HashPin(pin);
            await _storageService.SaveDataAsync(PinKey, hash);
        }

        public async Task<bool> ValidatePinAsync(string pin)
        {
            if (string.IsNullOrEmpty(pin))
                return false;

            var storedHash = await _storageService.GetDataAsync<string>(PinKey);
            if (string.IsNullOrEmpty(storedHash))
                return false;

            var inputHash = HashPin(pin);
            return storedHash == inputHash;
        }

        public async Task ClearPinAsync()
        {
            await _storageService.RemoveDataAsync(PinKey);
        }

        private string HashPin(string pin)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pin + "banking_salt"));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}