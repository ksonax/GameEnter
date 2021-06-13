using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GameEnter.Areas.Identity.Data;
using GameEnter.Dtos;
using AutoMapper;

namespace GameEnter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GamesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GameModels
        [HttpGet]
        public async Task<ActionResult<List<GameDto>>> GetGameModel()
        {
            var games = await _context.GameModel.ToListAsync();
            return games == null ? NoContent() : Ok(_mapper.Map<List<GameDto>>(games));
        }

        // GET: api/GameModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGameModel(int id)
        {
            var game = await _context.GameModel.SingleOrDefaultAsync(g => g.Id == id);

            return game == null ? NoContent() : Ok(_mapper.Map<GameDto>(game));
        }

        // PUT: api/GameModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutGameModel(int id, GameDto gameDto)
        {
            var game = await _context.GameModel.SingleOrDefaultAsync(g => g.Id == id);

            if (game == null)
                return BadRequest("Invalid game ID");
            
            _mapper.Map(gameDto, game);

            if (await _context.SaveChangesAsync() > 0)
                return NoContent();

            throw new Exception("Failed to update game");
        }

        // POST: api/GameModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGameModel(GameDto gameDto)
        {
            var game = new Game
            {
                Title = gameDto.Title,
                Genre = gameDto.Genre,
                ReleaseDate = gameDto.ReleaseDate

            };
            await _context.GameModel.AddAsync(game);
            if(await _context.SaveChangesAsync() > 0)
                return CreatedAtAction("GetGameModel", new { id = game.Id }, game);
            throw new Exception("Failed to create game");

        }

        // DELETE: api/GameModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameModel(int id)
        {
            var gameModel = await _context.GameModel.SingleOrDefaultAsync(g => g.Id == id);
            if (gameModel == null)
            {
                return BadRequest("Invalid game ID");
            }

            _context.GameModel.Remove(gameModel);
            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            throw new Exception("Failed to remove lobby");
        }

    }
}
