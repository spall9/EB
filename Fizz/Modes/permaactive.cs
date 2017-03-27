using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX.Direct3D9;
using ComboSettings = Fizz.Fmeniu;

namespace Fizz.Modes
{
    class permaactive
    {
        public static void Permaactive()
        {
            if (ComboSettings.ShowKillable)
                DamageIndicator.DamageToUnit = GetComboDamage;
            if (Player.Instance.HealthPercent <= ComboSettings.Use_hourglass && ItemManager.Zhonya.IsReady() && ItemManager.Zhonya.IsOwned())
            {
                ItemManager.UseZhonyas();
            }
            var target = EntityManager.Enemies.FirstOrDefault(t => t.IsValidTarget(Spells.Ignt.Range) && t.Health <= ObjectManager.Player.GetSummonerSpellDamage(t,DamageLibrary.SummonerSpells.Ignite));
            if (target != null && ComboSettings.useign)
            {
                Spells.Ignt.Cast(target);
            }
        }

        public static float GetComboDamage(Obj_AI_Base unit)
        {
            var d = 0f;

            if (Spells.Q.IsReady() && ComboSettings.combo_q)
                d += Player.Instance.GetSpellDamage(unit, SpellSlot.Q);

            if(Spells.W.IsReady() && ComboSettings.combo_w)
                d += Player.Instance.GetSpellDamage(unit, SpellSlot.W);

            if (Spells.E.IsReady() && ComboSettings.combo_e)
                d += Player.Instance.GetSpellDamage(unit, SpellSlot.E);

            if (Spells.R.IsReady() && ComboSettings.combo_r)
                d += Player.Instance.GetSpellDamage(unit, SpellSlot.R);

            if ((Player.Instance.GetSpellSlotFromName("summonerdot") == SpellSlot.Summoner1 ||
                            Player.Instance.GetSpellSlotFromName("summonerdot") == SpellSlot.Summoner2) && Fizz.Fmeniu.useign && Spells.Ignt.IsReady())
                d += Player.Instance.GetSummonerSpellDamage(unit, DamageLibrary.SummonerSpells.Ignite);

            if (ItemManager.BOTRK.IsReady() && ItemManager.BOTRK.IsOwned())
                d += Player.Instance.GetItemDamage(unit, ItemId.Blade_of_the_Ruined_King);

            if (ItemManager.Cutl.IsReady() && ItemManager.Cutl.IsOwned())
                d += Player.Instance.GetItemDamage(unit, ItemId.Bilgewater_Cutlass);

            if (ItemManager.Hydra.IsReady() && ItemManager.Hydra.IsOwned())
                d += Player.Instance.GetItemDamage(unit, ItemId.Ravenous_Hydra_Melee_Only);

            if (ItemManager.Tiamat.IsReady() && ItemManager.Tiamat.IsOwned())
                d += Player.Instance.GetItemDamage(unit, ItemId.Ravenous_Hydra_Melee_Only);

            if (ItemManager.HexTech.IsReady() && ItemManager.HexTech.IsOwned())
                d += Player.Instance.GetItemDamage(unit, ItemId.Hextech_Gunblade);

            d += Player.Instance.GetAutoAttackDamage(unit) * 3;

            return d;
        }
    }
    }

