using AutoMapper;
using GameEnter.Areas.Identity.Data;
using GameEnter.Data;
using GameEnter.Dtos;
using GameEnter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameEnter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserGamesController : Controller
    {
        private readonly UserManager<GameEnterUser> _userManager;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserGamesController(DataContext context, IMapper mapper, UserManager<GameEnterUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGamesDto>> GetUserGames(string id)
        {
            var userGames = await _context.UserGamesModel.FirstOrDefaultAsync(g => g.User.Id == id);
            return userGames == null ? NoContent() : Ok(_mapper.Map<UserGamesDto>(userGames));

        }


        [HttpPost("{id?}")]
        public async Task<ActionResult<UserGamesDto>> AddGameToAccount(int id, UserGamesDto userGamesDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userLibrary = new List<Game>();
            var game = await _context.GameModel.SingleOrDefaultAsync(g => g.Id == id);
            userLibrary.Add(game);


            var userGamesToAdd = new UserGames
            {
                User = user,
                UserLibrary = userLibrary
            };

            await _context.UserGamesModel.AddAsync(userGamesToAdd);

            if (await _context.SaveChangesAsync() > 0)
                return CreatedAtAction("GetUserGames", new { id = userGamesToAdd.Id }, userGamesDto);

            throw new Exception("Failed to add game");

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserGamesModel(int id)
        {
            var userGameModel = await _context.UserGamesModel.Include(u => u.UserLibrary).SingleOrDefaultAsync(g => g.Id == id);

            if (userGameModel == null)
            {
                return BadRequest("Invalid userGames ID");
            }
            
            _context.UserGamesModel.Remove(userGameModel);
            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            throw new Exception("Failed to remove user games");
        }
    }
}
