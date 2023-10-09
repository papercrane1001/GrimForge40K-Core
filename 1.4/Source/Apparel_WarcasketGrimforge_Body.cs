using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Verse;
using VFEPirates;

namespace Grimforge
{
    public class Apparel_WarcasketGrimforge_Body : Apparel_WarcasketGrimforge
    {

        private float energy = 50;
        public Apparel_Warcasket helm;
        public Apparel_Warcasket pads;

        public List<GFAA_AbilityPassive> passives;
        public List<GFAA_AbilityPassive> Passives
        {
            get
            {
                Log.Message("Ping1");
                if (passives == null)
                {
                    Log.Message("Ping2");
                    //GFAA_AbilityPassive test = Activator.CreateInstance<GFAA_AbilityPassive>();
                    Log.Message("V passives count: " + def.passives.Count.ToString());
                    GFAA_AbilityPassive test = new GFAA_AbilityPassive(Wearer, def.passives[0]);
                    //test.def = def.passives[0];
                    return new List<GFAA_AbilityPassive>() {  test };

                }
                else return passives;
            }
        }
        public List<Ability_Passive> AllPassiveAbilities
        {
            get
            {
                if(abilities_Passives.Count == 0) { abilities_Passives.Add(new TestPassive(Wearer)); }
                List<Ability_Passive> list = new List<Ability_Passive>(abilities_Passives);
                if (helm != null && helm is Apparel_WarcasketGrimforge_Helm)
                {
                    Apparel_WarcasketGrimforge_Helm hel = (Apparel_WarcasketGrimforge_Helm)helm;
                    if (hel.abilities_Passives != null)
                    {
                        list.AddRange(hel.abilities_Passives);
                    }
                }
                if (pads != null && pads is Apparel_WarcasketGrimforge_Pads)
                {
                    Apparel_WarcasketGrimforge_Pads pad = (Apparel_WarcasketGrimforge_Pads)pads;
                    if (pad.abilities_Passives != null)
                    {
                        list.AddRange(pad.abilities_Passives);
                    }
                }

                return list;
            }
            set
            {
                abilities_Passives = value;
            }
        }

        public float GetTotalDrain
        {
            get
            {
                float totalDrain = 0;
                for(int i = 0; i < AllPassiveAbilities.Count; ++i)
                {
                    if (AllPassiveAbilities[i].Active)
                    {
                        totalDrain += AllPassiveAbilities[i].Drain;
                    }
                }
                return totalDrain;
            }
        }

        public List<Ability_Active> AllActiveAbilities
        {
            get
            {
                //Debug

                List<Ability_Active> list = abilities_Active;
                if (helm != null && helm is Apparel_WarcasketGrimforge_Helm)
                {
                    Apparel_WarcasketGrimforge_Helm hel = (Apparel_WarcasketGrimforge_Helm)helm;
                    if (hel.abilities_Passives != null)
                    {
                        list.AddRange(hel.abilities_Active);
                    }
                }
                if (pads != null && pads is Apparel_WarcasketGrimforge_Pads)
                {
                    Apparel_WarcasketGrimforge_Pads pad = (Apparel_WarcasketGrimforge_Pads)pads;
                    if (pad.abilities_Passives != null)
                    {
                        list.AddRange(pad.abilities_Active);
                    }
                }

                return list;
            }
        }



        public float MaxEnergy { get { return def.maxEnergyAmount; } set { def.maxEnergyAmount = value; } }
        public float Energy
        {
            get
            {
                if (energy > def.maxEnergyAmount) { energy = def.maxEnergyAmount; }
                return energy;
            }
            set
            {
                energy = value;
                if (energy < 0) { energy = 0; }
                else if (energy > def.maxEnergyAmount) { energy = def.maxEnergyAmount; }
            }
        }
        public override void Tick()
        {
            base.Tick();
            energy = GetTotalDrain > energy ? 0 : energy - GetTotalDrain;
            if(energy <= 0)
            {
                TurnOffAllPassives();
            }
        }

        public void TurnOffAllPassives()
        {
            for(int i = 0; i < AllPassiveAbilities.Count; ++i)
            {
                AllPassiveAbilities[i].Set(false);
            }
        }

        public override void TickLong()
        {
            base.TickLong();
            //NOTE: I suspect this is where the actual energy drain will occur.  
        }

        public override IEnumerable<Gizmo> GetWornGizmos()
        {
            //Log.Message("GetWornGizmos in Body firing");
            foreach (var gizmo in base.GetWornGizmos())
            {
                yield return gizmo;
            }

            if (Find.Selector.SingleSelectedThing == Wearer && Wearer.IsColonistPlayerControlled)
            {
                var gizmo_ArmorEnergyStatus = new Gizmo_ArmorEnergyStatus
                {
                    casket = this
                };
                yield return gizmo_ArmorEnergyStatus;
            }

            if (Prefs.DevMode)
            {
                //Log.Message("ifDevMode within GetWornGizmos firing");
                //Log.Message("Ping1");
                //GFAA_AbilityPassive test = new GFAA_AbilityPassive(Wearer, GFAA_PassiveAbilityDefOf.GFAA_TEST);
                //Log.Message("Ping2");
                //yield return new Command_Toggle
                //{
                //    defaultLabel = "GF.TestPassiveLabelNEW".Translate(),
                //    defaultDesc = "GF.TEstPassiveLabelNEW".Translate(),
                //    isActive = () => test.Casting,
                //    //toggleAction = delegate { }
                //    toggleAction = test
                //}
                //Log.Message(test.gizmo.Desc);
                //yield return test.gizmo;
                Log.Message("Passives Count: ");
                Log.Message(Passives.Count().ToString());
                for(int i = 0; i < Passives.Count; ++i)
                {
                    yield return Passives[i].gizmo;
                }

                yield return new Command_Toggle
                {
                    defaultLabel = "GF.TestPassiveLabelOLD".Translate(),
                    defaultDesc = "GF.TestPassiveDescOLD".Translate(),
                    //hotkey
                    icon = ContentFinder<Texture2D>.Get("TEST/chest"),
                    //isActive = () => IsActive()
                    isActive = () => IsActive("TestPassiveName"),
                    toggleAction = delegate { SwitchPassive("TestPassiveName"); }
                };

                yield return new Command_Action
                {
                    defaultLabel = "GF.TestActiveHalveLabelOLD".Translate(),
                    defaultDesc = "GF.TestActiveHalveDescOLD".Translate(),
                    //icon
                    action = delegate { TestHalveEnergyAction(); }
                };
                //yield return new Command_Action
                Command_Action subtract = new Command_Action
                {
                    defaultLabel = "GF.TestActiveSubtractLabelOLD".Translate(),
                    defaultDesc = "GF.TestActiveSubtractDescOLD".Translate(),
                    //icon
                    action = delegate { TestRemoveEnergyAction(); }                    
                };

                if(energy < 25) { subtract.disabled = true; }
                yield return subtract;
                yield return new Command_Action
                {
                    defaultLabel = "GF.TestActiveAddLabel".Translate(),
                    defaultDesc = "GF.TestActiveAddDesc".Translate(),
                    //icon
                    action = delegate { TestAddEnergyAction(); }
                };
            }

            //for(int i = 0; i < AllPassiveAbilities.Count; i++)
            //{
            //    //Log.Message("AllPassiveAbilitiesCount = " + AllPassiveAbilities.Count.ToString());
            //    yield return new Command_Toggle
            //    {
            //        defaultLabel = "Passive" + i.ToString(),
            //        defaultDesc = "GF.TestPassiveDesc".Translate(),
            //        isActive = () => IsActive(AllPassiveAbilities[i].Name),
            //        toggleAction = delegate { SwitchPassive(AllPassiveAbilities[i].Name); }
            //    };
            //}

        }
        public override void SwitchPassive(string name)
        {
            Log.Message("SwitchPassiveInBody + " + name);
            for(int i = 0; i < AllPassiveAbilities.Count; i++)
            {
                Log.Message("Before: APA " + AllPassiveAbilities[i].Active.ToString());
                
                if (AllPassiveAbilities[i].Name == name)
                {
                    AllPassiveAbilities[i].Flip();
                }
                Log.Message("After: APA " + AllPassiveAbilities[i].Active.ToString());
            }
        }

        public override bool IsActive(string name)
        {
            if (AllPassiveAbilities.Where(x => x.Name == name && x.Active == true).Count() > 0)
            {
                return true;
            }

            return false;
        }

        public void TestHalveEnergyAction()
        {
            energy = energy / 2;
        }

        public void TestRemoveEnergyAction()
        {
            energy = energy - 25;
        }

        public void TestAddEnergyAction()
        {
            energy = energy + (def.maxEnergyAmount - energy) / 2;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref energy, "energy");
            //Scribe_Values.Look
        }
        //public FortyKCasketDef def => base.def as FortyKCasketDef;

    }
}
