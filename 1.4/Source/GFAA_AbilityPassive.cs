using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

//using VFECore.Abilities;

namespace Grimforge
{
    public class GFAA_AbilityPassive : Ability
    {
        public bool Active = false;
        public HediffDef HediffUsed { get { return GFAA_abilitydef.HediffUsed; } set { GFAA_abilitydef.HediffUsed = value; } }
        public virtual void GiveHediff()
        {
            Hediff hediff = HediffMaker.MakeHediff(HediffUsed, pawn);
            hediff.Severity = 0.5f;
            pawn.health.AddHediff(hediff);
        }
        public virtual void TakeHediff()
        {
            if(pawn.health.hediffSet.hediffs.Where(x => x.def == HediffUsed).Count() > 0)
            {
                Hediff hediff = pawn.health.hediffSet.hediffs.Where(x => x.def == HediffUsed).First();
                pawn.health.RemoveHediff(hediff);
            }
        }
        public virtual void Set(bool state)
        {
            Active = state;
            if (Active)
            {
                GiveHediff();
            }
            else
            {
                TakeHediff();
            }
        }
        public virtual void Toggle()
        {
            Active = !Active;
            if (Active)
            {
                GiveHediff();
            }
            else
            {
                TakeHediff();
            }
        }


        public float GFAA_Drain { get { return GFAA_abilitydef.GFAA_Drain; } set { GFAA_abilitydef.GFAA_Drain = value; } }

        public GFAA_PassiveAbilityDef GFAA_abilitydef { get; set; }

        public bool DevMode { get { return GFAA_abilitydef.DevMode; } }

        public GFAA_AbilityPassive(Pawn wearer, GFAA_PassiveAbilityDef ability) : base(wearer)
        {
            def = (AbilityDef)ability;
            GFAA_abilitydef = ability;

            gizmo = new Command_Toggle()
            {
                //defaultLabel = "GF.TestPassiveLabelOLD".Translate(),
                defaultLabel = ability.label,

                defaultDesc = ability.description,
                //hotkey
                //icon = ContentFinder<Texture2D>.Get("TEST/chest"),
                icon = ContentFinder<Texture2D>.Get(def.iconPath),
                //isActive = () => IsActive()
                isActive = () => Active,
                toggleAction = delegate { Toggle(); }
            };
        }
    }


    
}
