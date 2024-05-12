using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblGameStats
{
    public class EditModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public EditModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblGameStat TblGameStat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblgamestat =  await _context.TblGameStats.FirstOrDefaultAsync(m => m.Gamestatsid == id);
            if (tblgamestat == null)
            {
                return NotFound();
            }
            TblGameStat = tblgamestat;
           ViewData["Enemyid"] = new SelectList(_context.TblEnemies, "Enemyid", "Enemyid");
           ViewData["Playerid"] = new SelectList(_context.TblPlayers, "Playerid", "Playerid");
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

            _context.Attach(TblGameStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGameStatExists(TblGameStat.Gamestatsid))
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

        private bool TblGameStatExists(int id)
        {
            return _context.TblGameStats.Any(e => e.Gamestatsid == id);
        }
    }
}
