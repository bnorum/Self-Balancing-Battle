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
    public class IndexModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public IndexModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

        public IList<TblPlayer> TblPlayer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblPlayer = await _context.TblPlayers.ToListAsync();
        }
    }
}
