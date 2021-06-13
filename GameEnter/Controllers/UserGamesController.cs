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
using System.Threading.Tasks;

namespace GameEnter.Controllers
{

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
        public async Task<ActionResult<List<UserGamesDto>>> GetUserGames(string userId)
        {
            var userGames = await _context.UserGamesModel.SingleOrDefaultAsync(g => g.User.Id == userId);
            return userGames == null ? NoContent() : Ok(_mapper.Map<List<UserGamesDto>>(userGames));

        }

        [HttpPost("{id?}")]
        public async Task<ActionResult<UserGamesDto>> AddGameToAccount(UserGamesDto userGamesDto, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userGamesToAdd = new UserGames
            {
                User = user,
                UserLibrary = new List<Game>()
            };

            await _context.UserGamesModel.AddAsync(userGamesToAdd);

            if (await _context.SaveChangesAsync() > 0)
                return CreatedAtAction("GetUserGames", new { id = userGamesToAdd.Id }, userGamesDto);

            throw new Exception("Failed to add game");

        }
    }
}
