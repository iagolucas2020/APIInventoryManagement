using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories;
using APIInventoryManagement.API.Repositories.Interfaces;
using APIInventoryManagement.API.Services.Interfaces;

namespace APIInventoryManagement.API.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ILogsRepository _logsRepository;

        public StockService(IStockRepository stockRepository, ILogsRepository logsRepository)
        {
            _stockRepository = stockRepository;
            _logsRepository = logsRepository;
        }

        public async Task<IEnumerable<Stock>> GetAsync()
        {
            try
            {
                return await _stockRepository.GetAsync();
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            try
            {
                return await _stockRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Stock> PostAsync(Stock stock)
        {
            try
            {
                return await _stockRepository.PostAsync(stock);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Stock> PutAsync(Stock stock)
        {
            try
            {
                return await _stockRepository.PutAsync(stock);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            };
        }

        public async Task Delete(Stock stock)
        {
            try
            {
                await _stockRepository.Delete(stock);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
            }
        }
    }
}
