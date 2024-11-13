﻿using InventarioDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMoventDetailController(Ciclo8InventarioContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InventoryMoventDetail>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int? page = null, int? pageSize = null)
        {
            var query = context.InventoryMoventDetails.AsQueryable();

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
        [ProducesResponseType(typeof(InventoryMoventDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var inventoryMoventDetail = await context.InventoryMoventDetails.FirstOrDefaultAsync(x => x.IdMoventDetail == id);

            if (inventoryMoventDetail == null)
            {
                return NotFound();
            }

            return Ok(inventoryMoventDetail);
        }

        [HttpPost]
        [ProducesResponseType(typeof(InventoryMoventDetail), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] InventoryMoventDetail inventoryMoventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.InventoryMoventDetails.AddAsync(inventoryMoventDetail);
            await context.SaveChangesAsync();

            return Ok(inventoryMoventDetail);
        }

        [HttpPut]
        [ProducesResponseType(typeof(InventoryMoventDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] InventoryMoventDetail inventoryMoventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.InventoryMoventDetails.Update(inventoryMoventDetail);
            await context.SaveChangesAsync();

            return Ok(inventoryMoventDetail);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var inventoryMoventDetail = await context.InventoryMoventDetails.FirstOrDefaultAsync(x => x.IdMoventDetail == id);

            if (inventoryMoventDetail == null)
            {
                return NotFound();
            }

            context.InventoryMoventDetails.Remove(inventoryMoventDetail);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
