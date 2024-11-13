using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Permission>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            if(page <= 0)
            {
                return BadRequest(new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5",
                    Title = "Bad Request",
                    Detail = "page cannot be equal to or less than 0"
                });
            }

            var query = context.Permissions.AsQueryable();

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
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await context.Permissions.FirstOrDefaultAsync(x => x.IdPermission == id);

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Permissions.AddAsync(permission);
            await context.SaveChangesAsync();

            return Ok(permission);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Permissions.Update(permission);
            await context.SaveChangesAsync();

            return Ok(permission);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await context.Permissions.FirstOrDefaultAsync(x => x.IdPermission == id);

            if (permission == null)
            {
                return NotFound();
            }

            context.Permissions.Remove(permission);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
