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
                    for (int i = 0; i < def.passives.Count; ++i)
                    {
                        GFAA_AbilityPassive temp = new GFAA_AbilityPassive(Wearer, def.passives[0]);
                        passives.Add(temp);
                    }
                    return passives;

                }
                else return passives;
            }
        }
    }
}
