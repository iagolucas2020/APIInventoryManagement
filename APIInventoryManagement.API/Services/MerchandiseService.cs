using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using APIInventoryManagement.API.Services.Interfaces;
using APIInventoryManagement.API.Services.Shared;
using System.Text;

namespace APIInventoryManagement.API.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly ILogsRepository _logsRepository;

        public MerchandiseService(IMerchandiseRepository merchandiseRepository, ILogsRepository logsRepository)
        {
            _merchandiseRepository = merchandiseRepository;
            _logsRepository = logsRepository;
        }

        public async Task<IEnumerable<Merchandise>> GetAsync()
        {
            try
            {
                return await _merchandiseRepository.GetAsync();
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Merchandise> GetByIdAsync(int id)
        {
            try
            {
                return await _merchandiseRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Merchandise> PostAsync(Merchandise merchandise)
        {
            try
            {
                return await _merchandiseRepository.PostAsync(merchandise);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task<Merchandise> PutAsync(Merchandise merchandise)
        {
            try
            {
                return await _merchandiseRepository.PutAsync(merchandise);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
                return null;
            }
        }

        public async Task Delete(Merchandise merchandise)
        {
            try
            {
                await _merchandiseRepository.Delete(merchandise);
            }
            catch (Exception ex)
            {
                await _logsRepository.Insert(new Logs(ex.Message, DateTime.Now));
            }
        }

        public async Task GeneretePdf(string path)
        {
            StringBuilder rel = new StringBuilder();
            IEnumerable<Merchandise> merchandise = await _merchandiseRepository.GetAsync();
            Usefuls.merchandisesPdf(path, merchandise);
        }
    }
}
