using APIInventoryManagement.API.Models;

namespace APIInventoryManagement.API.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAsync();
        Task<IEnumerable<Stock>> GetFilterAsync(DateTime initial, DateTime final);
        Task<IEnumerable<Stock>> GetStockWithMechandisesAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<Stock> PostAsync(Stock stock);
        Task<Stock> PutAsync(Stock stock);
        Task Delete(Stock stock);
        Task GeneretePdf(string path, DateTime initial, DateTime final);
        Task<int> CheckAvailableStock(int merchandiseId);
        Task<IEnumerable<Stock>> GetMerchadisesIdAsync(int merchandiseId);
    }
}
