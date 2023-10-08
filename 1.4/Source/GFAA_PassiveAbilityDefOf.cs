using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace Grimforge
{
    public class GFAA_PassiveAbilityDef : AbilityDef
    {
        public HediffDef HediffUsed { get; set; }
        public string GFAA_Drain { get; set; }
    }

    [DefOf]
    public class GFAA_PassiveAbilityDefOf
    {
        public static GFAA_PassiveAbilityDef GFAA_PoweredMode;
        public static GFAA_PassiveAbilityDef GFAA_Overdrive;
        public static GFAA_PassiveAbilityDef GFAA_TEST;
    }
}
