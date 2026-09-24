using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleterasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BilleterasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Billeteras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billetera>>> GetBilletera()
        {
            return await _context.Billetera.ToListAsync();
        }

        // GET: api/Billeteras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Billetera>> GetBilletera(int id)
        {
            var billetera = await _context.Billetera.FindAsync(id);

            if (billetera == null)
            {
                return NotFound();
            }

            return billetera;
        }

        // PUT: api/Billeteras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilletera(int id, Billetera billetera)
        {
            if (id != billetera.Id)
            {
                return BadRequest();
            }

            _context.Entry(billetera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilleteraExists(id))
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

        // POST: api/Billeteras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Billetera>> PostBilletera(Billetera billetera)
        {
            _context.Billetera.Add(billetera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBilletera", new { id = billetera.Id }, billetera);
        }

        // DELETE: api/Billeteras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilletera(int id)
        {
            var billetera = await _context.Billetera.FindAsync(id);
            if (billetera == null)
            {
                return NotFound();
            }

            _context.Billetera.Remove(billetera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BilleteraExists(int id)
        {
            return _context.Billetera.Any(e => e.Id == id);
        }
    }
}
