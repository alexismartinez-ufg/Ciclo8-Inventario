using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Deparment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            var query = context.Deparments.AsQueryable();

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
        [ProducesResponseType(typeof(Deparment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var department = await context.Deparments.FirstOrDefaultAsync(x => x.IdDeparment == id);

            if(department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Deparment), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Deparment deparment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Deparments.AddAsync(deparment);
            await context.SaveChangesAsync();

            return Ok(deparment);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Deparment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Deparment deparment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Deparments.Update(deparment);
            await context.SaveChangesAsync();

            return Ok(deparment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await context.Deparments.FirstOrDefaultAsync(x => x.IdDeparment == id);

            if (department == null)
            {
                return NotFound();
            }

            context.Deparments.Remove(department);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
