using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblEnemy
{
    public class DeleteModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public DeleteModel(NorumBradenFinal.Bnorum1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEnemy TblEnemy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblenemy = await _context.TblEnemies.FirstOrDefaultAsync(m => m.Enemyid == id);

            if (tblenemy == null)
            {
                return NotFound();
            }
            else
            {
                TblEnemy = tblenemy;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblenemy = await _context.TblEnemies.FindAsync(id);
            if (tblenemy != null)
            {
                TblEnemy = tblenemy;
                _context.TblEnemies.Remove(TblEnemy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
