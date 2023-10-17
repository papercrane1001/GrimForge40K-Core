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
    /// "Void shield"   Simple shield with massive HP pool but with slow regeneration (entire shield need 1/2 to 1 hours to recharge)
    public class GFAA_PassiveAbilityDef : AbilityDef
    {
        public HediffDef HediffUsed;
        public float GFAA_Drain;
        public bool DevMode;
    }

    [DefOf]
    public class GFAA_PassiveAbilityDefOf
    {
        public static GFAA_PassiveAbilityDef GFAA_PoweredMode;
        public static GFAA_PassiveAbilityDef GFAA_Overdrive;
        public static GFAA_PassiveAbilityDef GFAA_HealingSpecialist;
        public static GFAA_PassiveAbilityDef GFAA_TEST;
        public static GFAA_PassiveAbilityDef GFAA_Invisibility;
        public static GFAA_PassiveAbilityDef GFAA_Psyker;
        public static GFAA_PassiveAbilityDef GFAA_Techmarine;
        public static GFAA_PassiveAbilityDef GFAA_Chaplain;

    }
}
