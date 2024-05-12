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
    public class DetailsModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public DetailsModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

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
    }
}
