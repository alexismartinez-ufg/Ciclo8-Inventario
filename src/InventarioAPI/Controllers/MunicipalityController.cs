﻿using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Municipality>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            if (page <= 0)
            {
                return BadRequest(new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5",
                    Title = "Bad Request",
                    Detail = "page cannot be equal to or less than 0"
                });
            }

            var query = context.Municipalities.AsQueryable();

            if (page.HasValue || pageSize.HasValue)
            {
                int currentPage = page ?? 1;
                int recordsPerPage = pageSize.HasValue ? Math.Min(pageSize.Value, 20) : 20;

                query = query
                    .Skip((currentPage - 1) * recordsPerPage)
                    .Take(recordsPerPage);
            }

            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Municipality), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var municipality = await context.Municipalities.FirstOrDefaultAsync(x => x.IdMunicipality == id);

            if (municipality == null)
            {
                return NotFound();
            }

            return Ok(municipality);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Municipality), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Municipality municipality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Municipalities.AddAsync(municipality);
            await context.SaveChangesAsync();

            return Ok(municipality);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Municipality), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Municipality municipality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Municipalities.Update(municipality);
            await context.SaveChangesAsync();

            return Ok(municipality);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var municipality = await context.Municipalities.FirstOrDefaultAsync(x => x.IdMunicipality == id);

            if (municipality == null)
            {
                return NotFound();
            }

            context.Municipalities.Remove(municipality);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
