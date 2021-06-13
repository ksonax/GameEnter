﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;
using GameEnter.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using GameEnter.Areas.Identity.Data;

namespace GameEnter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<GameEnterUser> _userManager;

        public LobbyController(DataContext context, IMapper mapper, UserManager<GameEnterUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: api/Lobby
        [HttpGet]
        public async Task<ActionResult<List<LobbyDto>>> GetLobbyModel()
        {
            var lobbies = await _context.LobbyModel.ToListAsync();
            return lobbies == null ? NoContent() : Ok(_mapper.Map<List<LobbyDto>>(lobbies));

        }

        // GET: api/Lobby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LobbyDto>> GetLobby(int id)
        {
            var lobby = await _context.LobbyModel.SingleOrDefaultAsync(g => g.Id == id);

            return lobby == null ? NoContent() : Ok(_mapper.Map<LobbyDto>(lobby));
        }

        // PUT: api/Lobby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLobby(int id, LobbyDto lobbyDto)
        {
            var lobby = await _context.LobbyModel.SingleOrDefaultAsync(l => l.Id == id);

            if (lobby == null)
                return BadRequest("Invalid lobby ID");

            _mapper.Map(lobbyDto, lobby);

            if (await _context.SaveChangesAsync() > 0)
                return NoContent();

            throw new Exception("Failed to update lobby");
        }

        // POST: api/Lobby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<LobbyDto>> PostLobby(LobbyDto lobbyDto, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            Game game = null;

            if(lobbyDto.LobbyGame != null)
                game = (await _context.GameModel.SingleOrDefaultAsync(g => g.Id == lobbyDto.LobbyGame.Id));

            var users = await _context.LobbyModel.Include(l => l.Users).ToListAsync();

            var lobby = new Lobby
            {
                Name = lobbyDto.Name,
                LobbyGame = game,
                Owner = user,
                Users = new List<GameEnterUser>()
            };

            await _context.LobbyModel.AddAsync(lobby);
            
            if(await _context.SaveChangesAsync() > 0)
                return CreatedAtAction("GetLobby", new { id = lobby.Id }, lobbyDto);
            
            throw new Exception("Failed to create lobby");

        }

        // DELETE: api/Lobby/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLobby(int id)
        {
            var lobby = await _context.LobbyModel.SingleOrDefaultAsync(l => l.Id == id);
            if (lobby == null)
            {
                return BadRequest("Invalid lobby ID");
            }

            _context.LobbyModel.Remove(lobby);
            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            throw new Exception("Failed to remove lobby");
        }

    }
}
