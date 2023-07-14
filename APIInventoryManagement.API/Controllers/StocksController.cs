using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIInventoryManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> Get()
        {
            try
            {
                var stock = await _stockRepository.GetAsync();
                if (stock is null)
                    return NotFound();
                return stock.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("{id:int}", Name = "GetStock")]
        public async Task<ActionResult<Stock>> GetById(int id)
        {
            try
            {
                var stock = await _stockRepository.GetByIdAsync(id);
                if (stock is null)
                    return NotFound($"Id: {id} not found!");
                return stock;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Stock stock)
        {
            try
            {
                if (stock is null)
                    return BadRequest("Invalid data!");

                await _stockRepository.PostAsync(stock);

                return new CreatedAtRouteResult("GetStock", new { id = stock.Id }, stock);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Stock stock)
        {
            try
            {
                if (id != stock.Id)
                    return BadRequest("Invalid data!");

                await _stockRepository.PutAsync(stock);

                return Ok(stock);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var stock = await _stockRepository.GetByIdAsync(id);
                if (stock is null)
                    return NotFound($"Id: {id} not found!");

                await _stockRepository.Delete(stock);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
