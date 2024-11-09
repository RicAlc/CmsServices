using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsServices.Context;
using CmsServices.Models;
using System.Globalization;

namespace CmsServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            var result = await _context.Facturas
                .Join(_context.Usuarios,
                    factura => factura.id_usuario,
                    usuario => usuario.id,
                    (factura, usuario) => new
                    {
                        factura.id,
                        factura.folio,
                        factura.fecha_facturacion,
                        factura.fecha_creacion,
                        factura.saldo,
                        cliente_nombre = usuario.nombre + " " + usuario.apellido,
                    })
                .ToListAsync();
            return Ok(result);
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            DateTime currentDate = DateTime.Now;
            factura.fecha_creacion = currentDate;
            factura.folio = await GenerateUniqueFolioAsync();

            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura", new { id = factura.id }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.id == id);
        }

        private async Task<string> GenerateUniqueFolioAsync()
        {
            string folio;
            do
            {
                folio = await GenerateFolioAsync(); 
            }
            while (await _context.Facturas.AnyAsync(i => i.folio == folio));

            return folio;
        }

        private async Task<string> GenerateFolioAsync()
        {
            var now = DateTime.Now;
            string dateString = now.ToString("yyMMdd", CultureInfo.InvariantCulture);
            int countToday = await _context.Facturas.CountAsync(i => i.folio.StartsWith($"F-{dateString}"));

            return $"F-{dateString}-{countToday + 1}";
        }
    }
}
