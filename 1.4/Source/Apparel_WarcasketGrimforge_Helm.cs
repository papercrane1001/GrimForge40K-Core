using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Grimforge
{
    public class Apparel_WarcasketGrimforge_Helm : Apparel_WarcasketGrimforge
    {
        public List<GFAA_AbilityPassive> passives;
        public List<GFAA_AbilityPassive> Passives
        {
            get
            {
                //Log.Message("Ping1");
                if (passives == null)
                {
                    passives = new List<GFAA_AbilityPassive>();
                    //Log.Message("def.passives.Count: " + def.passives.Count.ToString());
                    GFAA_AbilityPassive test = new GFAA_AbilityPassive(Wearer, def.passives[0]);
                    if (test.gizmo == null) { Log.Message("test.gizmo null"); }
                    passives.Add(test);
                    return passives;

                }
                else return passives;
            }
        }
    }
}
