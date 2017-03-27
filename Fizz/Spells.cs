using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Fizz
{
    using SharpDX;

    class Spells
    {
        public static Spell.Targeted Q;

        public static Spell.Active W;

        public static Spell.Skillshot E;

        public static Spell.Skillshot R;

        public static Spell.Targeted Ignt;

        public static void FSpellsloud()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 550);
            W = new Spell.Active(SpellSlot.W, (uint)Player.Instance.GetAutoAttackRange());
            E = new Spell.Skillshot(SpellSlot.E, 400, SkillShotType.Circular, 250, int.MaxValue, 330);
            R = new Spell.Skillshot(SpellSlot.R, 1300, SkillShotType.Linear, 250, 1200, 80)
            {
              AllowedCollisionCount = int.MaxValue,
            };
            E.AllowedCollisionCount = int.MaxValue;
            if (Player.Instance.GetSpellSlotFromName("summonerdot") != SpellSlot.Unknown)
                Ignt = new Spell.Targeted(Player.Instance.GetSpellSlotFromName("summonerdot"), 600);
        }

        public static void CastR(Obj_AI_Base target, string mode)
        {
            var Rpred = R.GetPrediction(target);
            if (R.IsReady() && Rpred.HitChance >= HitChance.Medium)
            {

                if (!target.HasBuff("summonerbarrier") || !target.HasBuff("BlackShield")
                    || !target.HasBuff("SivirShield") || !target.HasBuff("BansheesVeil")
                    || !target.HasBuff("ShroudofDarkness"))
                {
                    switch (mode)
                    {
                        case "Always":
                            R.Cast(Rpred.CastPosition);
                            break;
                        case "Only if killable":
                            if (Modes.permaactive.GetComboDamage(target) >= target.Health) R.Cast(Rpred.CastPosition);
                            break;
                    }
                }
            }
        }
    }
}
