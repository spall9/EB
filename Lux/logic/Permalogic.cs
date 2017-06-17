using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using System;
using System.Linq;

namespace lux.logic
{
    class Permalogic
    {
        public static void autoQifhit2x(Obj_AI_Base target)
        {
            if (Spells.Q.GetPrediction(target).CollisionObjects.Length == 0)
            {
                Chat.Print(Spells.Q.GetPrediction(target).CollisionObjects.Count());
            }
        }
        public static void AutoQIfEnemyImmobile(Obj_AI_Base target)
        {
            if (Extension.IsEnemyImmobile(target) && Spells.Q.GetPrediction(target).HitChance >= HitChance.High )
            {
                Spells.Q.Cast(target);
            }
        }
        public static void AutoEIfEnemyImmobile(Obj_AI_Base target)
        {
            if (Extension.IsEnemyImmobile(target) && Spells.E.GetPrediction(target).HitChance >= HitChance.High)
            {
                Spells.E.Cast(target);
            }
            if (Extension.ECheck() == 2)
            {
                Spells.E.Cast(target);
            }
        }
        public static void AutoRIfEnemyKillable(Obj_AI_Base target)
        {
            if (Spells.R.GetPrediction(target).HitChance >= HitChance.High && Spells.GetDamage(target, SpellSlot.R) >= Prediction.Health.GetPrediction(target, Spells.R.CastDelay))
            {
                Spells.R.Cast(target);
            }
        }
    }
}
