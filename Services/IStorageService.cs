using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface IStorageService
    {
        Task SaveDataAsync<T>(string key, T data);
        Task<T?> GetDataAsync<T>(string key);
        Task RemoveDataAsync(string key);
    }
}