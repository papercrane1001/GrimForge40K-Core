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
                    if(def.passives != null)
                    {
                        for (int i = 0; i < def.passives.Count; ++i)
                        {
                            GFAA_AbilityPassive temp = new GFAA_AbilityPassive(Wearer, def.passives[0]);
                            passives.Add(temp);
                        }
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
                if (actives == null)
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
    }
}
