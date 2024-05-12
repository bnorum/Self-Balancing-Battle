using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblEnemy
{
    public class EditModel : PageModel
    {
        private readonly NorumBradenFinal.Bnorum1Context _context;

        public EditModel(NorumBradenFinal.Bnorum1Context context)
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

            var tblenemy =  await _context.TblEnemies.FirstOrDefaultAsync(m => m.Enemyid == id);
            if (tblenemy == null)
            {
                return NotFound();
            }
            TblEnemy = tblenemy;
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

            _context.Attach(TblEnemy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEnemyExists(TblEnemy.Enemyid))
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

        private bool TblEnemyExists(int id)
        {
            return _context.TblEnemies.Any(e => e.Enemyid == id);
        }
    }
}
