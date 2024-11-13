using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserRole>), StatusCodes.Status200OK)]
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

            var query = context.UserRoles.AsQueryable();

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
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var userRole = await context.UserRoles.FirstOrDefaultAsync(x => x.IdRole == id);

            if (userRole == null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();

            return Ok(userRole);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.UserRoles.Update(userRole);
            await context.SaveChangesAsync();

            return Ok(userRole);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var userRole = await context.UserRoles.FirstOrDefaultAsync(x => x.IdRole == id);

            if (userRole == null)
            {
                return NotFound();
            }

            context.UserRoles.Remove(userRole);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
