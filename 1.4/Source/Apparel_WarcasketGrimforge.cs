using UnityEngine;
using Verse;
using VFEPirates;
using RimWorld.IO;

using System.Collections.Generic;
using System.Linq;

namespace Grimforge
{
    public class Apparel_WarcasketGrimforge : Apparel_Warcasket
    {
        public Color? colorApparelTwo;


        public override Color DrawColor
        {
            set 
            { 
                colorApparel = value; 
            }
        }
        public override Color DrawColorTwo
        {
            get
            {
                //return colorApparelTwo ??= this.def.colorGenerator.NewRandomizedColor();
                //There's a compact way to do this, but something's going wrong
                if(colorApparelTwo == null)
                {
                    colorApparelTwo = this.def.colorGenerator.NewRandomizedColor();
                }
                return (Color)colorApparelTwo;
            }
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref colorApparelTwo, "colorApparelTwo");
        }

        public FortyKCasketDef def => base.def as FortyKCasketDef;


        public override IEnumerable<Gizmo> GetWornGizmos()
        {
            //Log.Message("GetWornGizmos in base firing");

            foreach (var gizmo in base.GetWornGizmos())
            {
                yield return gizmo;
            }

        }
    }
}
