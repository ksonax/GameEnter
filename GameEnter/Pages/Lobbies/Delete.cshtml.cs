using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;
using Microsoft.AspNetCore.Authorization;

namespace GameEnter.Pages
{
    [Authorize(Roles = "Admin,SuperAdmin, LobbyOwner")]
    public class DeleteModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public DeleteModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lobby Lobby { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lobby = await _context.LobbyModel.FirstOrDefaultAsync(m => m.Id == id);

            if (Lobby == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lobby = await _context.LobbyModel.FindAsync(id);

            if (Lobby != null)
            {
                _context.LobbyModel.Remove(Lobby);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
