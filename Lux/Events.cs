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
        public static void OnUpdate(GameObject obj, EventArgs args)
        {
            var missile = obj as MissileClient;
            if (missile != null &&
                missile.SpellCaster != null &&
                missile.SpellCaster.IsEnemy &&
                missile.SpellCaster.Type == GameObjectType.AIHeroClient &&
                logic.Wlogic.ProjectileList.Contains(missile))
            {
                logic.Wlogic.ProjectileList.Remove(missile);
                logic.Wlogic.ProjectileList.Add(missile);
            }
        }

        public static void OnCreate(GameObject obj, EventArgs args)
        {
            var missile = obj as MissileClient;
            if (missile != null &&
                missile.SpellCaster != null &&
                missile.SpellCaster.IsEnemy &&
                missile.SpellCaster.Type == GameObjectType.AIHeroClient)
                logic.Wlogic.ProjectileList.Add(missile);
        }

        public static void OnDelete(GameObject obj, EventArgs args)
        {
            if (obj == null)
                return;

            var missile = obj as MissileClient;
            if (missile != null &&
                missile.SpellCaster != null &&
                missile.SpellCaster.IsEnemy &&
                missile.SpellCaster.Type == GameObjectType.AIHeroClient &&
                logic.Wlogic.ProjectileList.Contains(missile))
            {
                logic.Wlogic.ProjectileList.Remove(missile);
            }
        }
        public static void Game_OnTick(EventArgs args)
        {
            logic.Wlogic.TryToW();
            logic.junglesteal.ini();
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
            if(Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                Lux.jungleclear();
            }
            if (Spells.Ignite != null && !ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc, "use.ignite") && Spells.Ignite.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Ignite.Range, DamageType.True);
                if (target != null && target.IsValid())
                {
                    if (target.Health <= ObjectManager.Player.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Ignite))
                    {
                        Spells.Ignite.Cast(target);
                    }
                }
            }
            if (!ObjectManager.Player.IsDead && Extension.GetCheckBoxValue(Meniu.Misc,"auto.q") && Spells.Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (target != null && target.IsValid())
                {
                    Spells.Q.CastIfItWillHit(2,Extension.GetSliderValue(Meniu.Prediction, "q.prediction"));
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
                Spells.E.CastIfItWillHit(Extension.GetSliderValue(Meniu.Misc, "auto.e.min"),Extension.GetSliderValue(Meniu.Prediction, "e.prediction"));
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
