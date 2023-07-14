using APICarRegistration.Context;
using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;

namespace APIInventoryManagement.API.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly AppDbContext _context;

        public LogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(Logs log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
