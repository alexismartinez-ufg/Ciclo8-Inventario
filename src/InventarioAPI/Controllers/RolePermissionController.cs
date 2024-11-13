using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RolePermission>), StatusCodes.Status200OK)]
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

            var query = context.RolePermissions.AsQueryable();

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
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var rolePermission = await context.RolePermissions.FirstOrDefaultAsync(x => x.IdPermission == id);

            if (rolePermission == null)
            {
                return NotFound();
            }

            return Ok(rolePermission);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] RolePermission rolePermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.RolePermissions.AddAsync(rolePermission);
            await context.SaveChangesAsync();

            return Ok(rolePermission);
        }

        [HttpPut]
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] RolePermission rolePermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.RolePermissions.Update(rolePermission);
            await context.SaveChangesAsync();

            return Ok(rolePermission);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var rolePermission = await context.RolePermissions.FirstOrDefaultAsync(x => x.IdPermission == id);

            if (rolePermission == null)
            {
                return NotFound();
            }

            context.RolePermissions.Remove(rolePermission);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
