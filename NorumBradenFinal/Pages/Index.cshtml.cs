using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NorumBradenFinal.Pages.tblGameStats;
using System.Numerics;
using System;
using System.Collections;

namespace NorumBradenFinal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NorumBradenFinal.Bnorum1Context _context;
        public Dictionary<string, int> Player { get; set; }
        public Dictionary<string, int> Enemy { get; set; }


        public IndexModel(ILogger<IndexModel> logger, NorumBradenFinal.Bnorum1Context context)
        {
            _logger = logger;
            _context = context;

            
        }

        public IActionResult OnGet()
        {
            Player = new Dictionary<string, int>(); // Initialize Player dictionary
            Enemy = new Dictionary<string, int>(); // Initialize Enemy dictionary

            Player.Add("health", 100);
            Player.Add("maxhp", 100);
            Player.Add("mana", 20);
            Player.Add("maxmana", 20);
            Player.Add("attackPower", 10);
            Player.Add("magicPower", 20);
            Player.Add("totalMagicAttacks", 0);
            Player.Add("totalAttacks", 0);

            Enemy.Add("health", 100);
            Enemy.Add("maxhp", 100);
            Enemy.Add("attackPower", 10);
            ViewData["PlayerStats"] = Player;
            ViewData["EnemyStats"] = Enemy;
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

            // Generate random keys for playerid and enemyid
            Random random = new Random();
            var playerid = random.Next();
            var enemyid = random.Next();
            TblGameStat.Playerid = playerid;
            TblGameStat.Enemyid = enemyid;
            TblGameStat.Player.Playerid = playerid;

            TblGameStat.Enemy.Enemyid = enemyid;

            _context.TblGameStats.Add(TblGameStat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    
}
