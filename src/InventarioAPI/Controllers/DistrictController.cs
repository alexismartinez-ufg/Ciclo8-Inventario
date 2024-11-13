using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<District>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            var query = context.Districts.AsQueryable();

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
        [ProducesResponseType(typeof(District), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var district = await context.Districts.FirstOrDefaultAsync(x => x.IdDistrict == id);

            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        [HttpPost]
        [ProducesResponseType(typeof(District), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Districts.AddAsync(district);
            await context.SaveChangesAsync();

            return Ok(district);
        }

        [HttpPut]
        [ProducesResponseType(typeof(District), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Districts.Update(district);
            await context.SaveChangesAsync();

            return Ok(district);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var district = await context.Districts.FirstOrDefaultAsync(x => x.IdDistrict == id);

            if (district == null)
            {
                return NotFound();
            }

            context.Districts.Remove(district);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
