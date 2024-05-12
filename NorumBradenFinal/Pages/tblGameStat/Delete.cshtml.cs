using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblGameStats
{
    public class DeleteModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public DeleteModel(NorumBradenFinal.Bnorum1Context context)
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

            var tblgamestat = await _context.TblGameStats.FirstOrDefaultAsync(m => m.Gamestatsid == id);

            if (tblgamestat == null)
            {
                return NotFound();
            }
            else
            {
                TblGameStat = tblgamestat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblgamestat = await _context.TblGameStats.FindAsync(id);
            if (tblgamestat != null)
            {
                TblGameStat = tblgamestat;
                _context.TblGameStats.Remove(TblGameStat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
