﻿using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Brand>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            var query = context.Brands.AsQueryable();

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
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await context.Brands.FirstOrDefaultAsync(x => x.IdBrand == id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            return Ok(brand);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Brands.Update(brand);
            await context.SaveChangesAsync();

            return Ok(brand);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await context.Brands.FirstOrDefaultAsync(x => x.IdBrand == id);

            if (brand == null)
            {
                return NotFound();
            }

            context.Brands.Remove(brand);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
