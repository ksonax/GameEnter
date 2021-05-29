using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter.Pages
{
    public class CreateModel : PageModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public CreateModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lobby Lobby { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LobbyModel.Add(Lobby);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
