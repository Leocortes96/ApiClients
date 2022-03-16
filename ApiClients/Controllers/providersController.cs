using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClients.Data;
using ApiClients.Models;

namespace ApiClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class providersController : ControllerBase
    {
        private readonly ApiClientsContext _context;

        public providersController(ApiClientsContext context)
        {
            _context = context;
        }

        // GET: api/providers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<providers>>> Getproviders()
        {
            return await _context.providers.ToListAsync();
        }

        // GET: api/providers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<providers>> Getproviders(int id)
        {
            var providers = await _context.providers.FindAsync(id);

            if (providers == null)
            {
                return NotFound();
            }

            return providers;
        }

        // PUT: api/providers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproviders(int id, providers providers)
        {
            if (id != providers.id)
            {
                return BadRequest();
            }

            _context.Entry(providers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!providersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/providers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<providers>> Postproviders(providers providers)
        {
            _context.providers.Add(providers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproviders", new { id = providers.id }, providers);
        }

        // DELETE: api/providers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproviders(int id)
        {
            var providers = await _context.providers.FindAsync(id);
            if (providers == null)
            {
                return NotFound();
            }

            _context.providers.Remove(providers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool providersExists(int id)
        {
            return _context.providers.Any(e => e.id == id);
        }
    }
}
