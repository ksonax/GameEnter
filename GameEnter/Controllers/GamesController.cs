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
    public class GamesController : ControllerBase
    {
        private readonly GameDbContext _context;

        public GamesController(GameDbContext context)
        {
            _context = context;
        }

        // GET: api/GameModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGameModel()
        {
            return await _context.GameModel.ToListAsync();
        }

        // GET: api/GameModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameModel(int id)
        {
            var gameModel = await _context.GameModel.FindAsync(id);

            if (gameModel == null)
            {
                return NotFound();
            }

            return gameModel;
        }

        // PUT: api/GameModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameModel(int id, Game gameModel)
        {
            if (id != gameModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameModelExists(id))
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

        // POST: api/GameModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGameModel(Game gameModel)
        {
            _context.GameModel.Add(gameModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameModel", new { id = gameModel.Id }, gameModel);
        }

        // DELETE: api/GameModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameModel(int id)
        {
            var gameModel = await _context.GameModel.FindAsync(id);
            if (gameModel == null)
            {
                return NotFound();
            }

            _context.GameModel.Remove(gameModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameModelExists(int id)
        {
            return _context.GameModel.Any(e => e.Id == id);
        }
    }
}
