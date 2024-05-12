using System;
using System.Collections.Generic;
using NorumBradenFinal.Pages.tblGameStats;

namespace NorumBradenFinal.Pages.tblPlayer;

public partial class TblPlayer
{
    public int Playerid { get; set; }

    public int? Attack { get; set; }

    public int? Health { get; set; }

    public int? Magicpower { get; set; }

    public int? Mana { get; set; }

    public virtual ICollection<TblGameStat> TblGameStats { get; set; } = new List<TblGameStat>();
}
