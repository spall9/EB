using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace lux.logic
{
    class Rlogic
    {
        public static void FinisherR(Obj_AI_Base target)
        {
            if (Spells.R.GetPrediction(target).HitChance >= HitChance.High && Spells.GetDamage(target,SpellSlot.R) >= Prediction.Health.GetPrediction(target,Spells.R.CastDelay))
            {
                Spells.R.Cast(target);
            }
        }
        public static void MultiR(Obj_AI_Base target)
        {
            Spells.R.CastIfItWillHit(Extension.GetSliderValue(Meniu.Combo, "combo.r.min"), 75);
        }
        public static void Rchoise(Obj_AI_Base target)
        {
            switch (Extension.GetComboboxValue(Meniu.Combo, "combo.r.logic"))
            {
                case 0:
                    FinisherR(target);
                    break;
                case 1:
                    MultiR(target);
                    break;
                case 2:
                    FinisherR(target);
                    MultiR(target);
                    break;
            }
        }
    }
}
