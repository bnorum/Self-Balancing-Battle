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
    public class DetailsModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public DetailsModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

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
    }
}
