using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
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
    public class GFAA_ActiveAbilityDef : AbilityDef
    {
        //public float GFAA_DrainOnEnergy = 0;
        public float GFAA_DrainOnEnergy;
        public float GFAA_ChunkOfEnergy;
        public bool DevMode = false;
        //public bool DevMode;
    }

    [DefOf]
    public class GFAA_ActiveAbilityDefOf
    {
        public static GFAA_ActiveAbilityDef GFAA_PowerJump;
        public static GFAA_ActiveAbilityDef GFAA_AddEnergy;
        public static GFAA_ActiveAbilityDef GFAA_TakeEnergy;
        //public static GFAA_ActiveAbilityDef GFAA_FragOut;
        //public static GFAA_ActiveAbilityDef GFAA_KrakOut;
        //public static GFAA_ActiveAbilityDef GFAA_FireOnMyMark;
        //public static GFAA_ActiveAbilityDef GFAA_Charge;
        //public static GFAA_ActiveAbilityDef GFAA_GrapplingHook;
    }
}
