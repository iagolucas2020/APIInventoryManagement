using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIInventoryManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MerchandisesController : ControllerBase
    {
        private readonly IMerchandiseRepository _merchandiseRepository;

        public MerchandisesController(IMerchandiseRepository merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchandise>>> Get()
        {
            try
            {
                var merchandise = await _merchandiseRepository.GetAsync();
                if (merchandise is null)
                    return NotFound();
                return merchandise.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("{id:int}", Name = "GetMerchandise")]
        public async Task<ActionResult<Merchandise>> GetById(int id)
        {
            try
            {
                var merchandise = await _merchandiseRepository.GetByIdAsync(id);
                if (merchandise is null)
                    return NotFound($"Id: {id} not found!");
                return merchandise;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Merchandise merchandise)
        {
            try
            {
                if (merchandise is null)
                    return BadRequest("Invalid data!");

                await _merchandiseRepository.PostAsync(merchandise);

                return new CreatedAtRouteResult("GetMerchandise", new { id = merchandise.Id }, merchandise);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Merchandise merchandise)
        {
            try
            {
                if (id != merchandise.Id)
                    return BadRequest("Invalid data!");

                await _merchandiseRepository.PutAsync(merchandise);

                return Ok(merchandise);
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
                var merchandise = await _merchandiseRepository.GetByIdAsync(id);
                if (merchandise is null)
                    return NotFound($"Id: {id} not found!");

                await _merchandiseRepository.Delete(merchandise);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
