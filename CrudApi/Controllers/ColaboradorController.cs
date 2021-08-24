using CrudApi.Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase {
        private readonly CrudApiContext _context;

        public ColaboradorController(CrudApiContext context) {
            _context = context;
        }

        // GET: api/Colaborador
        [HttpGet("pagina/{id}")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador(int id) {
            int itensPorPagina = 500;
            return await _context.Colaborador
                .OrderBy(a => a.Nome)
                .ThenBy(b => b.Cpf)
                .Skip((id - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToListAsync();
        }

        // GET: api/Colaborador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(string id) {
            var colaborador = await _context.Colaborador.FindAsync(id);

            if (colaborador == null) {
                return NotFound();
            }

            return colaborador;
        }

        // POST: api/Colaborador
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador) {
            _context.Colaborador.Add(colaborador);
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (ColaboradorExists(colaborador.Cpf)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtAction("GetColaborador", new { id = colaborador.Cpf }, colaborador);
        }

        // DELETE: api/Colaborador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(string id) {
            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null) {
                return NotFound();
            }

            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboradorExists(string id) {
            return _context.Colaborador.Any(e => e.Cpf == id);
        }
    }
}
