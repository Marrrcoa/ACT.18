using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basededatos.Server.Contexto;
using Basededatos.Shared.models;

namespace Basededatos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productoesController : ControllerBase
    {
        private readonly ContextoTiendaMotoPartes _context;

        public productoesController(ContextoTiendaMotoPartes context)
        {
            _context = context;
        }

        // GET: api/productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Getproductos()
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            return await _context.productos.ToListAsync();
        }

        // GET: api/productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Getproducto(int id)
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            var producto = await _context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproducto(int id,    Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(id))
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

        // POST: api/productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> Postproducto(Producto producto)
        {
          if (_context.productos == null)
          {
              return Problem("Entity set 'ContextoTiendaMotoPartes.productos'  is null.");
          }
            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproducto(int id)
        {
            if (_context.productos == null)
            {
                return NotFound();
            }
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productoExists(int id)
        {
            return (_context.productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
