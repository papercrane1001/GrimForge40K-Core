﻿using System;
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
        public HediffDef HediffUsed { get { return GFAA_ability.HediffUsed; } set { GFAA_ability.HediffUsed = value; } }
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

        //public List<GFAA_AbilityPassive> passives;

        public float GFAA_Drain { get { return GFAA_ability.GFAA_Drain; } set { GFAA_ability.GFAA_Drain = value; } }

        GFAA_PassiveAbilityDef GFAA_ability { get; set; }

        public GFAA_AbilityPassive(Pawn wearer, GFAA_PassiveAbilityDef ability) : base(wearer)
        {
            def = (AbilityDef)ability;
            GFAA_ability = ability;
        }
    }


    public abstract class Ability_Passive
    {
        public Pawn pawn;
        public string Name { get; set; }
        public bool Active { get; set; }
        public float Drain { get; set; }

        public string Label { get; set; }
        public string Description { get; set; }
        //public Def
        //public Texture2D Texture { get; set; }
        public Action toggle_Action { get; set; }

        public HediffDef HediffUsed { get; set; }

        public virtual void Flip()
        {
            Active = !Active;
            if (Active) { GiveHediff(); }
            else { TakeHediff(); }
        }
        public virtual void Set(bool state)
        {
            Active = state;
            if (Active) { GiveHediff(); }
            else { TakeHediff(); }
        }

        public Ability_Passive(Pawn wearer)
        {
            pawn = wearer;
        }

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

    }

    public class OverdriveAbility : Ability_Passive
    {
        public OverdriveAbility(Pawn wearer) : base(wearer)
        {
            pawn = wearer;
            HediffUsed = HediffDefOf.GFAA_HediffOverdrive;
            Name = "OverdriveAbility";
            Active = false;
            Drain = 0.01f;

        }
        
    }

    public class TestPassive : Ability_Passive
    {
        public TestPassive(Pawn wearer) : base(wearer)
        {
            Name = "TestPassiveName";
            Active = false;
            Drain = 0.01f;
            
            //pawn.GetStatValue()
            //StatDef.
        }



        public override void Set(bool state)
        {
            Active = state;
            if (Active)
            {
                Hediff hediff = HediffMaker.MakeHediff( HediffDefOf.GFAA_HediffTEST, pawn);
                hediff.Severity = 0.5f;
                pawn.health.AddHediff(hediff);
            }
            else
            {
                Hediff hediff = HediffMaker.MakeHediff(HediffDefOf.GFAA_HediffTEST, pawn);
                pawn.health.RemoveHediff(hediff);
            }
        }
        public override void Flip()
        {
            base.Flip();
            if (Active)
            {
                //Log.Message("Ping Hediff Creation");
                Hediff hediff = HediffMaker.MakeHediff(HediffDefOf.GFAA_HediffTEST, pawn);
                hediff.Severity = 0.5f;
                pawn.health.AddHediff(hediff);
                Log.Message("Ping Hediff Flip");
            }
            else
            {
                Hediff hediff = HediffMaker.MakeHediff(HediffDefOf.GFAA_HediffTEST, pawn);
                pawn.health.RemoveHediff(hediff);
            }
        }
    }
}
