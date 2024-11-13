using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), StatusCodes.Status200OK)]
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

            var query = context.Suppliers.AsQueryable();

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
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.IdSupplier == id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();

            return Ok(supplier);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();

            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.IdSupplier == id);

            if (supplier == null)
            {
                return NotFound();
            }

            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
