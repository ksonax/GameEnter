using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public IndexModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Lobby> Lobby { get;set; }

        public async Task OnGetAsync()
        {
            Lobby = await _context.LobbyModel.ToListAsync();
        }
    }
}
