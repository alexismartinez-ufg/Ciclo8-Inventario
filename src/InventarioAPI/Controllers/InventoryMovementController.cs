using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementController(Ciclo8InventarioContext context) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InventoryMovement>), StatusCodes.Status200OK)]
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

            var query = context.InventoryMovements.AsQueryable();

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
        [ProducesResponseType(typeof(InventoryMovement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var movement = await context.InventoryMovements.FirstOrDefaultAsync(x => x.IdMovement == id);

            if (movement == null)
            {
                return NotFound();
            }

            return Ok(movement);
        }

        [HttpPost]
        [ProducesResponseType(typeof(InventoryMovement), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] InventoryMovement inventoryMovement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.InventoryMovements.AddAsync(inventoryMovement);
            await context.SaveChangesAsync();

            return Ok(inventoryMovement);
        }

        [HttpPut]
        [ProducesResponseType(typeof(InventoryMovement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] InventoryMovement inventoryMovement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.InventoryMovements.Update(inventoryMovement);
            await context.SaveChangesAsync();

            return Ok(inventoryMovement);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var movement = await context.InventoryMovements.FirstOrDefaultAsync(x => x.IdMovement == id);

            if (movement == null)
            {
                return NotFound();
            }

            context.InventoryMovements.Remove(movement);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
