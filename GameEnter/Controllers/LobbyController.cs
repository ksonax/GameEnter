using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly DataContext _context;

        public LobbyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Lobby
        [HttpGet]
        public async Task<ActionResult<List<Lobby>>> GetLobbyModel()
        {
            return await _context.LobbyModel.ToListAsync();

        }

        // GET: api/Lobby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lobby>> GetLobby(int id)
        {
            var lobby = await _context.LobbyModel.FindAsync(id);

            if (lobby == null)
            {
                return NotFound();
            }

            return lobby;
        }

        // PUT: api/Lobby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLobby(int id, Lobby lobby)
        {
            if (id != lobby.Id)
            {
                return BadRequest();
            }

            _context.Entry(lobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LobbyExists(id))
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

        // POST: api/Lobby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lobby>> PostLobby(Lobby lobby)
        {
            _context.LobbyModel.Add(lobby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLobby", new { id = lobby.Id }, lobby);
        }

        // DELETE: api/Lobby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLobby(int id)
        {
            var lobby = await _context.LobbyModel.FindAsync(id);
            if (lobby == null)
            {
                return NotFound();
            }

            _context.LobbyModel.Remove(lobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LobbyExists(int id)
        {
            return _context.LobbyModel.Any(e => e.Id == id);
        }
    }
}
