using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace lux
{
    class Events
    {
        public static void Game_OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Lux.combo();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Lux.harass();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Lux.laneclear();
            }
            if (!ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc,"auto.q") && Spells.Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (target != null && target.IsValid())
                {
                    Spells.Q.CastIfItWillHit(2, 75);
                }
            }
            if (!ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc, "auto.q.imo") && Spells.Q.IsReady())
            {
                foreach (var enemy in EntityManager.Enemies.Where(x => x.IsValidTarget(Spells.Q.Range) && !x.IsDead && !x.IsZombie && !x.IsMinion && !x.IsMonster))
                {
                    logic.Permalogic.AutoQIfEnemyImmobile(enemy);
                }

            }
            if (!ObjectManager.Player.IsDead && Spells.E.IsReady())
            {
                Spells.E.CastIfItWillHit(Extension.GetSliderValue(Meniu.Misc, "auto.e.min"), 85);
            }
            if (!ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc, "auto.e.imo") && Spells.E.IsReady())
            {
                foreach (var enemy in EntityManager.Enemies.Where(x => x.IsValidTarget(Spells.E.Range) && !x.IsDead && !x.IsZombie && !x.IsMinion && !x.IsMonster))
                {
                    logic.Permalogic.AutoEIfEnemyImmobile(enemy);
                }
            }
            if (!ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc, "auto.r") && Spells.R.IsReady())
            {
                foreach (var enemy in EntityManager.Enemies.Where(x => x.IsValidTarget(Spells.R.Range) && !x.IsDead && !x.IsZombie && !x.IsMinion && !x.IsMonster))
                {
                    logic.Permalogic.AutoRIfEnemyKillable(enemy);
                }
            }
        }
    }
}
