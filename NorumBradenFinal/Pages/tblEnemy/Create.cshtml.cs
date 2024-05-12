using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorumBradenFinal;

namespace NorumBradenFinal.Pages.tblEnemy
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
            return Page();
        }

        [BindProperty]
        public TblEnemy TblEnemy { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblEnemies.Add(TblEnemy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
