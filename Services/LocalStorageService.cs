using Microsoft.JSInterop;
using System.Text.Json;

namespace BankingApp.Services
{
    public class LocalStorageService : IStorageService
    {
        private readonly IJSRuntime _jsRuntime;
        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveDataAsync<T>(string key, T data)
        {
            var json = JsonSerializer.Serialize(data);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);

        }
        public async Task<T?> GetDataAsync<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
        public async Task RemoveDataAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}