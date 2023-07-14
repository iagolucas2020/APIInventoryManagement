using APIInventoryManagement.API.Models;

namespace APIInventoryManagement.API.Repositories.Interfaces
{
    public interface ILogsRepository
    {
        Task Insert(Logs log);
    }
}
