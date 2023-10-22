using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Grimforge
{
    

    public class GFAA_AbilityActive : Ability
    {
        //public float GFAA_Cost { get; set; }
        public GFAA_ActiveAbilityDef GFAA_ActiveDef;
        public bool DevMode { get { return GFAA_ActiveDef.DevMode; } }
        public float GFAA_DrainOnEnergy { get { return GFAA_ActiveDef.GFAA_DrainOnEnergy; } }
        public float GFAA_ChunkOfEnergy { get { return GFAA_ActiveDef.GFAA_ChunkOfEnergy; } }

        public GFAA_AbilityActive(Pawn wearer, GFAA_ActiveAbilityDef ability) : base(wearer)
        {
            def = (AbilityDef)ability;
            GFAA_ActiveDef = ability;

            //Log.Message("Ping Creation " + ability.label);
            //gizmo = new Command_ActionWithCooldown()
            //{
            //    defaultLabel = ability.label,
            //    defaultDesc = ability.description,
            //    icon = ContentFinder<Texture2D>.Get(def.iconPath),
            //    action = () => { }
            //};
        }

        public override bool Activate(GlobalTargetInfo target)
        {
            for(int i = 0; i < pawn.apparel.WornApparel.Count; ++i)
            {
                if (pawn.apparel.WornApparel[i] is Apparel_WarcasketGrimforge_Body bod)
                {
                    bod.Energy -= GFAA_ChunkOfEnergy;
                }
            }
            //foreach(Apparel_WarcasketGrimforge_Body bod in pawn.apparel.WornApparel)
            //{

            //}
            return base.Activate(target);
        }
        public override bool Activate(LocalTargetInfo target, LocalTargetInfo dest)
        {
            for (int i = 0; i < pawn.apparel.WornApparel.Count; ++i)
            {
                if (pawn.apparel.WornApparel[i] is Apparel_WarcasketGrimforge_Body bod)
                {
                    bod.Energy -= GFAA_ChunkOfEnergy;
                }
            }
            return base.Activate(target, dest);
        }
        public override bool CanCast //=> base.CanCast;
        {
            get
            {
                for(int i = 0; i < pawn.apparel.WornApparel.Count; i++)
                {
                    if (pawn.apparel.WornApparel[i] is Apparel_WarcasketGrimforge_Body body)
                    {
                        if(body.Energy > GFAA_ChunkOfEnergy)
                        {
                            return base.CanCast;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                Log.Message("Grimforge Warcasket not found, Ability not removed properly");
                return false;
            }
        }
    }
    
    
}
