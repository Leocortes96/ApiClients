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
    public class document_typeController : ControllerBase
    {
        private readonly ApiClientsContext _context;

        public document_typeController(ApiClientsContext context)
        {
            _context = context;
        }

        // GET: api/document_type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<document_type>>> Getdocument_type()
        {
            return await _context.document_type.ToListAsync();
        }

        // GET: api/document_type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<document_type>> Getdocument_type(int id)
        {
            var document_type = await _context.document_type.FindAsync(id);

            if (document_type == null)
            {
                return NotFound();
            }

            return document_type;
        }

        // PUT: api/document_type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdocument_type(int id, document_type document_type)
        {
            if (id != document_type.id)
            {
                return BadRequest();
            }

            _context.Entry(document_type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!document_typeExists(id))
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

        // POST: api/document_type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<document_type>> Postdocument_type(document_type document_type)
        {
            _context.document_type.Add(document_type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdocument_type", new { id = document_type.id }, document_type);
        }

        // DELETE: api/document_type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedocument_type(int id)
        {
            var document_type = await _context.document_type.FindAsync(id);
            if (document_type == null)
            {
                return NotFound();
            }

            _context.document_type.Remove(document_type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool document_typeExists(int id)
        {
            return _context.document_type.Any(e => e.id == id);
        }
    }
}
