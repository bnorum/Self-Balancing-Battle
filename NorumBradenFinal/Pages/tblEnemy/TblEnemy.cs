using System;
using System.Collections.Generic;
using NorumBradenFinal.Pages.tblGameStats;

namespace NorumBradenFinal.Pages.tblEnemy;

public partial class TblEnemy
{
    public int Enemyid { get; set; }

    public int? Enemyhealth { get; set; }

    public int? Enemyattack { get; set; }

    public virtual ICollection<TblGameStat> TblGameStats { get; set; } = new List<TblGameStat>();
}
