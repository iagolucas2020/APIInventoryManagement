﻿using APIInventoryManagement.API.Models;
using APIInventoryManagement.API.Repositories.Interfaces;
using APIInventoryManagement.API.Services.Interfaces;
using APIInventoryManagement.API.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace APIInventoryManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MerchandisesController : ControllerBase
    {
        //private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly IMerchandiseService _merchandiseService;
        private readonly IHostEnvironment _hostEnvironment;

        public MerchandisesController(IMerchandiseService merchandiseService, IHostEnvironment hostEnvironment)
        {
            _merchandiseService = merchandiseService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchandise>>> Get()
        {
            try
            {
                var merchandise = await _merchandiseService.GetAsync();
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
                var merchandise = await _merchandiseService.GetByIdAsync(id);
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

                await _merchandiseService.PostAsync(merchandise);

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

                await _merchandiseService.PutAsync(merchandise);

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
                var merchandise = await _merchandiseService.GetByIdAsync(id);
                if (merchandise is null)
                    return NotFound($"Id: {id} not found!");

                await _merchandiseService.Delete(merchandise);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GeneretePdf()
        {
            try
            {
                string pathDirectory = _hostEnvironment.ContentRootPath;
                await _merchandiseService.GeneretePdf(pathDirectory);
                return PhysicalFile(String.Concat(pathDirectory, "wwwroot\\temp\\arquivo.pdf"), "application/pdf", "arquivo.pdf");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
