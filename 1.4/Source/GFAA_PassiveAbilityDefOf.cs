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
        public HediffDef HediffUsed;
        public float GFAA_Drain;
        //public string testStringA;
        //public string test
        //public List<GFAA_AbilityPassive> passives;
    }

    [DefOf]
    public class GFAA_PassiveAbilityDefOf
    {
        public static GFAA_PassiveAbilityDef GFAA_PoweredMode;
        public static GFAA_PassiveAbilityDef GFAA_Overdrive;
        public static GFAA_PassiveAbilityDef GFAA_TEST;
    }
}
