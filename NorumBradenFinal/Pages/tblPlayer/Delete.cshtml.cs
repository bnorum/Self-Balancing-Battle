using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblPlayer
{
    public class DeleteModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public DeleteModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPlayer TblPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblplayer = await _context.TblPlayers.FirstOrDefaultAsync(m => m.Playerid == id);

            if (tblplayer == null)
            {
                return NotFound();
            }
            else
            {
                TblPlayer = tblplayer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblplayer = await _context.TblPlayers.FindAsync(id);
            if (tblplayer != null)
            {
                TblPlayer = tblplayer;
                _context.TblPlayers.Remove(TblPlayer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
