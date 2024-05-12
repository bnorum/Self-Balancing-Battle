using System;
using System.Collections.Generic;
using NorumBradenFinal.Pages.tblEnemy;
using NorumBradenFinal.Pages.tblPlayer;

namespace NorumBradenFinal.Pages.tblGameStats;

public partial class TblGameStat
{
    public int Gamestatsid { get; set; }

    public int? Turnstaken { get; set; }

    public int? Damagetaken { get; set; }

    public string? Name { get; set; }

    public int? Enemyid { get; set; }

    public int? Playerid { get; set; }

    public virtual TblEnemy? Enemy { get; set; }

    public virtual TblPlayer? Player { get; set; }
}
