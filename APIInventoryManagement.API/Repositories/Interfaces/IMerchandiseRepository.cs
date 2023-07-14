using APIInventoryManagement.API.Models;

namespace APIInventoryManagement.API.Repositories.Interfaces
{
    public interface IMerchandiseRepository
    {
        Task<IEnumerable<Merchandise>> GetAsync();
        Task<Merchandise> GetByIdAsync(int id);
        Task<Merchandise> PostAsync(Merchandise merchandise);
        Task<Merchandise> PutAsync(Merchandise merchandise);
        Task Delete(Merchandise merchandise);
    }
}
