using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameEnter.Data;
using GameEnter.Models;
using Microsoft.EntityFrameworkCore;
using GameEnter.Pages.Lobbies;
using System.Security.Claims;
using GameEnter.Areas.Identity.Data;

namespace GameEnter.Pages
{
    public class CreateModel : GamesInLobbyModel
    {
        private readonly GameEnter.Data.DataContext _context;

        public CreateModel(GameEnter.Data.DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            PopulateLobbyGameDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Lobby Lobby { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var lobbyToAdd = new Lobby();

            if (await TryUpdateModelAsync<Lobby>(
                 lobbyToAdd,
                 "lobby",   // Prefix for form value.
                 s => s.Name, s => s.LobbyGame))
            {
                _context.LobbyModel.Add(lobbyToAdd);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateLobbyGameDropDownList(_context, lobbyToAdd.LobbyGame);
            return Page();

        }
    }
}
