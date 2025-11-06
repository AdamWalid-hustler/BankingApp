using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface IPinService
    {
        Task<bool> HasPinAsync();
        Task SetPinAsync(string pin);
        Task<bool> ValidatePinAsync(string pin);
        Task ClearPinAsync();
    }
}