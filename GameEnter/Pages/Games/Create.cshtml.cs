using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameEnter.Data;
using GameEnter.Models;

namespace GameEnter
{
    public class CreateModel : PageModel
    {
        private readonly GameEnter.Data.MvcGameContext _context;

        public CreateModel(GameEnter.Data.MvcGameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameModel GameModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameModel.Add(GameModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
