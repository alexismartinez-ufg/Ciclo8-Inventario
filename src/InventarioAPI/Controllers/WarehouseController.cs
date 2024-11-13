using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Warehouse>), StatusCodes.Status200OK)]
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

            var query = context.Warehouses.AsQueryable();

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
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var warehouse = await context.Warehouses.FirstOrDefaultAsync(x => x.IdWarehouse == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Warehouses.AddAsync(warehouse);
            await context.SaveChangesAsync();

            return Ok(warehouse);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Warehouses.Update(warehouse);
            await context.SaveChangesAsync();

            return Ok(warehouse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await context.Warehouses.FirstOrDefaultAsync(x => x.IdWarehouse == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            context.Warehouses.Remove(warehouse);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
