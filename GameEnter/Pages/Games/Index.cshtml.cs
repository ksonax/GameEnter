using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter
{
    public class IndexModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public IndexModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Game> GameModel { get;set; }

        public async Task OnGetAsync()
        {
            GameModel = await _context.GameModel.ToListAsync();
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
