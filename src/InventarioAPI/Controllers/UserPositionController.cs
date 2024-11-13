using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPositionController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserPosition>), StatusCodes.Status200OK)]
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

            var query = context.UserPositions.AsQueryable();

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
        [ProducesResponseType(typeof(UserPosition), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var userPosition = await context.UserPositions.FirstOrDefaultAsync(x => x.IdUserPosition == id);

            if (userPosition == null)
            {
                return NotFound();
            }

            return Ok(userPosition);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserPosition), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] UserPosition userPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.UserPositions.AddAsync(userPosition);
            await context.SaveChangesAsync();

            return Ok(userPosition);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserPosition), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UserPosition userPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.UserPositions.Update(userPosition);
            await context.SaveChangesAsync();

            return Ok(userPosition);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var userPosition = await context.UserPositions.FirstOrDefaultAsync(x => x.IdUserPosition == id);

            if (userPosition == null)
            {
                return NotFound();
            }

            context.UserPositions.Remove(userPosition);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
