using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblGameStats
{
    public class CreateModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public CreateModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Enemyid"] = new SelectList(_context.TblEnemies, "Enemyid", "Enemyid");
        ViewData["Playerid"] = new SelectList(_context.TblPlayers, "Playerid", "Playerid");
            return Page();
        }

        [BindProperty]
        public TblGameStat TblGameStat { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblGameStats.Add(TblGameStat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
