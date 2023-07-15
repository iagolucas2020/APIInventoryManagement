using APIInventoryManagement.API.Models;

namespace APIInventoryManagement.API.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<IEnumerable<Merchandise>> GetAsync();
        Task<Merchandise> GetByIdAsync(int id);
        Task<Merchandise> PostAsync(Merchandise merchandise);
        Task<Merchandise> PutAsync(Merchandise merchandise);
        Task Delete(Merchandise merchandise);
        Task GeneretePdf(string path);
    }
}
