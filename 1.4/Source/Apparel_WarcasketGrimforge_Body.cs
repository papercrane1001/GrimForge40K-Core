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
        public Apparel_WarcasketGrimforge_Helm _hel;
        //public bool 
        public Apparel_WarcasketGrimforge_Helm helm
        {
            get
            {
                if (_hel != null) { return _hel; }
                for(int i = 0;i < Wearer.apparel.WornApparel.Count; ++i)
                {
                    if (Wearer.apparel.wornApparel[i] is Apparel_WarcasketGrimforge_Helm helm)
                    {
                        _hel = helm;
                        return _hel;
                    }
                }
                return null;
            }
        }
        public Apparel_WarcasketGrimforge_Pads _ads;
        public Apparel_Warcasket pads
        {
            get
            {
                if (_ads != null) { return _ads; }
                for(int i = 0; i < Wearer.apparel.WornApparel.Count; ++i)
                {
                    if (Wearer.apparel.WornApparel[i] is Apparel_WarcasketGrimforge_Pads pads)
                    {
                        _ads = pads;
                        return _ads;
                    }
                }
                return null;
            }
        }

        public List<GFAA_AbilityPassive> passives;
        public List<GFAA_AbilityPassive> Passives
        {
            get
            {
                //Log.Message("Ping1");
                if (passives == null)
                {
                    passives = new List<GFAA_AbilityPassive>();
                    for (int i = 0; i < def.passives.Count; ++i)
                    {
                        GFAA_AbilityPassive temp = new GFAA_AbilityPassive(Wearer, def.passives[i]);
                        passives.Add(temp);
                    }
                    return passives;

                }
                else return passives;
            }
        }
        public List<GFAA_AbilityActive> actives;
        public List<GFAA_AbilityActive> Actives
        {
            get
            {
                if(actives == null)
                {
                    actives = new List<GFAA_AbilityActive>();
                    if(def.actives != null)
                    {
                        for (int i = 0; i < def.actives.Count; ++i)
                        {
                            actives.Add(new GFAA_AbilityActive(Wearer, def.actives[i]));
                        }
                    }                    
                    return actives;
                }
                else return actives;
            }
        }

        public float GetTotalDrain
        {
            get
            {
                float totalDrain = 0;
                for (int i = 0; i < Passives.Count; ++i)
                {
                    if (AllPassiveAbilities[i].Active)
                    {
                        totalDrain += AllPassiveAbilities[i].GFAA_Drain;
                    }
                }
                return totalDrain;
            }
        }

        //public override void Notify_Equipped(Pawn pawn)
        //{
        //    base.Notify_Equipped(pawn);

        //}

        //public override ti

        public override void Notify_Unequipped(Pawn pawn)
        {
            base.Notify_Unequipped(pawn);


        }


        public List<GFAA_AbilityPassive> AllPassiveAbilities
        {
            get
            {
                List<GFAA_AbilityPassive> list = Passives;
                if (helm != null && helm is Apparel_WarcasketGrimforge_Helm)
                {
                    Apparel_WarcasketGrimforge_Helm hel = (Apparel_WarcasketGrimforge_Helm)helm;
                    if (hel.Passives != null && hel.Passives.Count > 0)
                    {
                        list.AddRange(hel.Passives);
                    }
                }
                if (pads != null && pads is Apparel_WarcasketGrimforge_Pads)
                {
                    Apparel_WarcasketGrimforge_Pads pad = (Apparel_WarcasketGrimforge_Pads)pads;
                    if (pad.Passives != null && pad.Passives.Count > 0)
                    {
                        list.AddRange(pad.Passives);
                    }
                }
                return list;
            }
        }
        public List<GFAA_AbilityActive> AllActiveAbilities
        {
            get
            {
                List<GFAA_AbilityActive> list = Actives;
                if (helm != null && helm is Apparel_WarcasketGrimforge_Helm)
                {
                    Apparel_WarcasketGrimforge_Helm hel = (Apparel_WarcasketGrimforge_Helm)helm;
                    if (hel.Passives != null)
                    {
                        list.AddRange(hel.Actives);
                    }
                }
                if (pads != null && pads is Apparel_WarcasketGrimforge_Pads)
                {
                    Apparel_WarcasketGrimforge_Pads pad = (Apparel_WarcasketGrimforge_Pads)pads;
                    if (pad.Passives != null)
                    {
                        list.AddRange(pad.Actives);
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
            if (energy <= 0)
            {
                TurnOffAllPassives();
            }
        }

        public void TurnOffAllPassives()
        {
            for (int i = 0; i < AllPassiveAbilities.Count; ++i)
            {
                AllPassiveAbilities[i].Set(false);
            }
        }

        //public override void TickLong()
        //{
        //    base.TickLong();
        //    Log.Message("TickLong");
        //    for (int i = 0; i < AllActiveAbilities.Count; i++)
        //    {
        //        if (!Wearer.abilities.abilities.Contains(AllActiveAbilities[i]))
        //        {
        //            //GFAA_AbilityActive ability = AbilityUtility.MakeAbility()
        //            Log.Message("Ping adding ability");
        //            Wearer.abilities.abilities.Add(AllActiveAbilities[i]);
        //        }
        //    }

        //}

        public override IEnumerable<Gizmo> GetWornGizmos()
        {
            for (int i = 0; i < AllActiveAbilities.Count; i++)
            {
                if (!Wearer.abilities.abilities.Contains(AllActiveAbilities[i]))
                {
                    //GFAA_AbilityActive ability = AbilityUtility.MakeAbility()
                    Log.Message("Ping adding ability");
                    Wearer.abilities.abilities.Add(AllActiveAbilities[i]);
                }
            }


            //Log.Message("GetWornGizmos in Body firing");
            foreach (var gizmo in base.GetWornGizmos())
            {
                yield return gizmo;
            }
            //Log.Message("base.GetWornGizmos() done");


            if (Find.Selector.SingleSelectedThing == Wearer && Wearer.IsColonistPlayerControlled)
            {
                var gizmo_ArmorEnergyStatus = new Gizmo_ArmorEnergyStatus
                {
                    casket = this
                };
                yield return gizmo_ArmorEnergyStatus;
            }

            for (int i = 0; i < AllPassiveAbilities.Count; ++i)
            {
                //if (Prefs.DevMode) { yield return AllPassiveAbilities[i].gizmo; }
                //else if (!AllPassiveAbilities[i].DevMode) { yield return AllPassiveAbilities[i].gizmo; }
                yield return AllPassiveAbilities[i].gizmo;
            }
            //for (int i = 0; i < AllActiveAbilities.Count; ++i)
            //{
            //    yield return AllActiveAbilities[i].gizmo;
            //}

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
