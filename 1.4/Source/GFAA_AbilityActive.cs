using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;

namespace Grimforge
{
    /// <summary>
    /// "Frag Grenade" Simple damage ability with small/medium size AOE
    /// Krak Grenade Simple anti armor grenade, single target
    /// "Fire on my mark" Aura which gives less aim time and higher accuracy
    /// "Charge!"     Aura which gives melee attack cooldown reduction, dodge chance, bonus movement speed, automatic switch weapons to melee (if possible) (if its possible to code)
    /// "Grappling hook"     Dash which need to be "connect" to wall
    /// </summary>
    /// 

    public class GFAA_AbilityActive : Ability
    {
        public float GFAA_Cost { get; set; }
    }
    
    
}
