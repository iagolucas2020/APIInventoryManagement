using APICarRegistration.Context;
using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIInventoryManagement.API.Repositories
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly AppDbContext _context;

        public MerchandiseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Merchandise>> GetAsync()
        {
            var merchandise = await _context.Merchandises.AsNoTracking().ToListAsync();
            return merchandise;
        }

        public async Task<Merchandise> GetByIdAsync(int id)
        {
            var merchandise = await _context.Merchandises.FindAsync(id);
            return merchandise;
        }

        public async Task<Merchandise> PostAsync(Merchandise merchandise)
        {
            _context.Add(merchandise);
            await _context.SaveChangesAsync();
            return merchandise;
        }

        public async Task<Merchandise> PutAsync(Merchandise merchandise)
        {
            _context.Entry(merchandise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return merchandise;
        }

        public async Task Delete(Merchandise merchandise)
        {
            _context.Remove(merchandise);
            await _context.SaveChangesAsync();
        }
    }
}
