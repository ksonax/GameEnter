using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter.Pages
{
    public class EditModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public EditModel(GameEnter.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LobbyExists(Lobby.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LobbyExists(int id)
        {
            return _context.LobbyModel.Any(e => e.Id == id);
        }
    }
}
