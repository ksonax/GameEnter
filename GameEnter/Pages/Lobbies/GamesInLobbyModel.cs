using GameEnter.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameEnter.Pages.Lobbies
{
    public class GamesInLobbyModel : PageModel
    {
        public SelectList GameNameSL { get; set; }

        public void PopulateLobbyGameDropDownList(DataContext _context,
            object selectedGame = null)
        {
            var gamesQuery = from d in _context.GameModel
                                   orderby d.Title // Sort by name.
                                   select d;

            GameNameSL = new SelectList(gamesQuery.AsNoTracking(),
                        "Id", "Title", selectedGame);
        }
    }
}
