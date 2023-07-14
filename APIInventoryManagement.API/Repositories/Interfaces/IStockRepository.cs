using APIInventoryManagement.API.Models;

namespace APIInventoryManagement.API.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<Stock> PostAsync(Stock stock);
        Task<Stock> PutAsync(Stock stock);
        Task Delete(Stock stock);
    }
}
