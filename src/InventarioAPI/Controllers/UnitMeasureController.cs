﻿using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMeasureController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitMeasure>), StatusCodes.Status200OK)]
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

            var query = context.UnitMeasures.AsQueryable();

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
        [ProducesResponseType(typeof(UnitMeasure), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var unitMeasure = await context.UnitMeasures.FirstOrDefaultAsync(x => x.IdUnitMeasure == id);

            if (unitMeasure == null)
            {
                return NotFound();
            }

            return Ok(unitMeasure);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UnitMeasure), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] UnitMeasure unitMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.UnitMeasures.AddAsync(unitMeasure);
            await context.SaveChangesAsync();

            return Ok(unitMeasure);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UnitMeasure), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UnitMeasure unitMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.UnitMeasures.Update(unitMeasure);
            await context.SaveChangesAsync();

            return Ok(unitMeasure);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var unitMeasure = await context.UnitMeasures.FirstOrDefaultAsync(x => x.IdUnitMeasure == id);

            if (unitMeasure == null)
            {
                return NotFound();
            }

            context.UnitMeasures.Remove(unitMeasure);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
