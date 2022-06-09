using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiProyectoSmart.Models;

namespace apiProyectoSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IF4101_ParkingLotContext _context;

        public TicketsController()
        {
            _context = new IF4101_ParkingLotContext();
        }

        // GET: api/Tickets
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.Include(s => s.User).Include(S => S.ParkingLot).Include(s => s.RateType).Include(s => s.Spot).Select(studentItem => new Ticket()
            {
                IdTicket = studentItem.IdTicket,
                ParkingLot = studentItem.ParkingLot,
                User = studentItem.User,
                RateType = studentItem.RateType,
                Spot = studentItem.Spot,
                StarDay = studentItem.StarDay,
                EndDay = studentItem.EndDay,

            }).ToListAsync();

        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
          if (_context.Tickets == null)
          {
              return NotFound();
          }
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.IdTicket)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
          if (_context.Tickets == null)
          {
              return Problem("Entity set 'IF4101_ParkingLotContext.Tickets'  is null.");
          }
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.IdTicket }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public void DeleteTicket(int id)
        {
           
            var ticket =  _context.Tickets.Find(id);
            if (ticket == null)
            {
              
            }

            _context.Tickets.Remove(ticket);
             _context.SaveChanges();

        }

        private bool TicketExists(int id)
        {
            return (_context.Tickets?.Any(e => e.IdTicket == id)).GetValueOrDefault();
        }
    }
}
