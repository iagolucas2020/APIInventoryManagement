using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Services;
using APIInventoryManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace APIInventoryManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IHostEnvironment _hostEnvironment;

        public StocksController(IStockService stockService, IHostEnvironment hostEnvironment)
        {
            _stockService = stockService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> Get()
        {
            try
            {
                var stock = await _stockService.GetAsync();
                if (stock is null)
                    return NotFound();
                return stock.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("stocks")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStockWithMechandises()
        {
            try
            {
                var stock = await _stockService.GetStockWithMechandisesAsync();
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
                var stock = await _stockService.GetByIdAsync(id);
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

                await _stockService.PostAsync(stock);

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

                await _stockService.PutAsync(stock);

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
                var stock = await _stockService.GetByIdAsync(id);
                if (stock is null)
                    return NotFound($"Id: {id} not found!");

                await _stockService.Delete(stock);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<Stock>>> Get(DateTime initial, DateTime final)
        {
            try
            {
                var stock = await _stockService.GetFilterAsync(initial, final);
                if (stock is null)
                    return NotFound();
                return stock.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GeneretePdf(DateTime initial, DateTime final)
        {
            try
            {
                string pathDirectory = _hostEnvironment.ContentRootPath;
                await _stockService.GeneretePdf(pathDirectory, initial, final);
                return PhysicalFile(String.Concat(pathDirectory, "wwwroot\\temp\\arquivo.pdf"), "application/pdf", "arquivo.pdf");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
