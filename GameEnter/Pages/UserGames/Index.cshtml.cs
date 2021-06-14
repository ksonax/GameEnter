using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;
using System.Security.Claims;

namespace GameEnter
{
    public class UserGamesIndexModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public UserGamesIndexModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Game> GameModel { get;set; }

        public async Task OnGetAsync()
        {
            var userGames = await _context.UserGamesModel.SingleOrDefaultAsync(x => x.User.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(userGames.UserLibrary != null)
                GameModel = userGames.UserLibrary.ToList();
        }
        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            return RedirectToPage("./UserGames");
        }
    }
}
