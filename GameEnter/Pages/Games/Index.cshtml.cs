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
        private readonly GameEnter.Data.MvcGameContext _context;

        public IndexModel(GameEnter.Data.MvcGameContext context)
        {
            _context = context;
        }

        public IList<GameModel> GameModel { get;set; }

        public async Task OnGetAsync()
        {
            GameModel = await _context.GameModel.ToListAsync();
        }
    }
}
