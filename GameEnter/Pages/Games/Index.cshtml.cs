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
        private readonly GameEnter.Data.GameDbContext _context;

        public IndexModel(GameEnter.Data.GameDbContext context)
        {
            _context = context;
        }

        public IList<Game> GameModel { get;set; }

        public async Task OnGetAsync()
        {
            GameModel = await _context.GameModel.ToListAsync();
        }
    }
}
