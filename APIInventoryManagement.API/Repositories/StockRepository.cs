using APICarRegistration.Context;
using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIInventoryManagement.API.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAsync()
        {
            var stock = await _context.Stocks.AsNoTracking().ToListAsync();
            return stock;
        }

        public async Task<IEnumerable<Stock>> GetStockWithMechandisesAsync()
        {
            var stock = await _context.Stocks.Include(m => m.Merchandise).AsNoTracking().ToListAsync();
            return stock;
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            return stock;
        }

        public async Task<Stock> PostAsync(Stock stock)
        {
            _context.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> PutAsync(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task Delete(Stock stock)
        {
            _context.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}
