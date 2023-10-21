using RimWorld;
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
        public float GFAA_Cost { get; set; }
        public GFAA_ActiveAbilityDef GFAA_ActiveDef;
        public bool DevMode { get { return GFAA_ActiveDef.DevMode; } }
        public float GFAA_DrainOnEnergy { get { return GFAA_ActiveDef.GFAA_DrainOnEnergy; } }
        public float GFAA_ChunkOfEnergy { get { return GFAA_ActiveDef.GFAA_ChunkOfEnergy; } }

        public GFAA_AbilityActive(Pawn wearer, GFAA_ActiveAbilityDef ability) : base(wearer)
        {
            def = (AbilityDef)ability;
            GFAA_ActiveDef = ability;

            //gizmo = new Command_ActionWithCooldown()
            //{
            //    defaultLabel = ability.label,
            //    defaultDesc = ability.description,
            //    icon = ContentFinder<Texture2D>.Get(def.iconPath),
            //    action = () => { }
            //};
        }


        public override bool CanCast //=> base.CanCast;
        {
            get
            {

            }
        }
    }
    
    
}
