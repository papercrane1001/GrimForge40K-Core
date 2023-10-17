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
    /// <summary>
    /// "Void shield"   Simple shield with massive HP pool but with slow regeneration (entire shield need 1/2 to 1 hours to recharge)
    /// "Invisibility"
    /// "Healing specialist"     Aura which speedup tending wounds even tending wounds itself
    ///+50% speed/quality tend
    ///+50% success surgery rate
    ///"Psyker" 
    ///He can cast spells from mamy magic schools
    ///100% Meditation psyfocus gain 
    ///+ 50 % Neural heat recovery rate
    ///+ 25 % Psychic Sensitivity
    ///"Techmarine"
    ///+ 5 to craft
    ///+ 50 % to craft/smith/trailor speed
    ///1+ to craft quality
    ///Chaplain
    ///+5 to social
    ///+100% suppression
    ///+75% to social impact


    /// </summary>
    /// 

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
            Hediff hediff = HediffMaker.MakeHediff(HediffUsed, pawn);
            pawn.health.RemoveHediff(hediff);
            
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

        //public List<GFAA_AbilityPassive> passives;

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
