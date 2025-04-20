using Microsoft.AspNetCore.Mvc;
using HotelConsagradoAPI.Data;
using HotelConsagradoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelConsagradoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly HotelConsagradoDbContext _context;

        public ReservasController(HotelConsagradoDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.Include(r => r.Hospedes).ToListAsync();
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.Include(r => r.Hospedes).FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaCreateViewModel reservaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserva = new Reserva
            {
                DataCheckIn = reservaViewModel.DataCheckIn,
                DataCheckOut = reservaViewModel.DataCheckOut,
                QuantidadeAdultos = reservaViewModel.QuantidadeAdultos,
                QuantidadeCriancas = reservaViewModel.QuantidadeCriancas,
                QuantidadeQuartos = reservaViewModel.QuantidadeQuartos,
                NomeResponsavel = reservaViewModel.NomeResponsavel,
                EmailResponsavel = reservaViewModel.EmailResponsavel,
                TelefoneResponsavel = reservaViewModel.TelefoneResponsavel,
                Hospedes = new List<Hospede>()
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        // POST: api/Reservas/{reservaId}/Hospedes
        [HttpPost("{reservaId}/Hospedes")]
        public async Task<ActionResult<Hospede>> PostHospede(int reservaId, Hospede hospede)
        {
            var reserva = await _context.Reservas.FindAsync(reservaId);
            if (reserva == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            hospede.ReservaId = reservaId;
            _context.Hospedes.Add(hospede);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospede", new { id = hospede.Id }, hospede);
        }

        // GET: api/Reservas/Hospedes/{id}
        [HttpGet("Hospedes/{id}")]
        public async Task<ActionResult<Hospede>> GetHospede(int id)
        {
            var hospede = await _context.Hospedes.FindAsync(id);

            if (hospede == null)
            {
                return NotFound();
            }

            return hospede;
        }

        // PUT: api/Reservas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaUpdateViewModel reservaViewModel)
        {
            if (id != reservaViewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            reserva.DataCheckIn = reservaViewModel.DataCheckIn;
            reserva.DataCheckOut = reservaViewModel.DataCheckOut;
            reserva.QuantidadeAdultos = reservaViewModel.QuantidadeAdultos;
            reserva.QuantidadeCriancas = reservaViewModel.QuantidadeCriancas;
            reserva.QuantidadeQuartos = reservaViewModel.QuantidadeQuartos;
            reserva.NomeResponsavel = reservaViewModel.NomeResponsavel;
            reserva.EmailResponsavel = reservaViewModel.EmailResponsavel;
            reserva.TelefoneResponsavel = reservaViewModel.TelefoneResponsavel;

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // DELETE: api/Reservas/5
        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("Hospedes/{id}")]
        public async Task<IActionResult> PutHospede(int id, Hospede hospede)
        {
            if (id != hospede.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(hospede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospedeExists(id))
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

        // DELETE: api/Reservas/Hospedes/5
        [HttpDelete("Hospedes/{id}")]
        public async Task<IActionResult> DeleteHospede(int id)
        {
            var hospede = await _context.Hospedes.FindAsync(id);
            if (hospede == null)
            {
                return NotFound();
            }

            _context.Hospedes.Remove(hospede);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
        private bool HospedeExists(int id)
        {
            return _context.Hospedes.Any(e => e.Id == id);
        }
    }
}