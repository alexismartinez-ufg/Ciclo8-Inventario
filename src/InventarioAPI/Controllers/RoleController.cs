﻿using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Role>), StatusCodes.Status200OK)]
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

            var query = context.Roles.AsQueryable();

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
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.IdRole == id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();

            return Ok(role);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Roles.Update(role);
            await context.SaveChangesAsync();

            return Ok(role);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.IdRole == id);

            if (role == null)
            {
                return NotFound();
            }

            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
