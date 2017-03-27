using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = Fizz.Fmeniu;
using Spells = Fizz.Spells;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Fizz.Modes
{
    class harras
    {
        public static void Harras()
        {

            switch (Settings.HarassMode)
            {
                case "Safe Mode":
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    if (target == null || !target.IsValidTarget()) return;
                    if (Events.LastHarassPos == Vector3.Zero)
                        Events.LastHarassPos = Player.Instance.Position;

                    if (Spells.W.IsReady() && Settings.harras_w && Spells.Q.IsReady() && Settings.harras_q && Spells.E.IsReady())
                    {
                        Spells.W.Cast();
                        Spells.Q.Cast(target);
                    }

                    if (Spells.E.IsReady() && Settings.harras_e && !Spells.W.IsReady() && !Spells.Q.IsReady())
                    {
                        Spells.E.Cast(Player.Instance.Position.Extend(Events.LastHarassPos, Spells.E.Range - 1).To3DWorld());

                        Core.DelayAction(() =>
                        {
                            Spells.E.Cast(Player.Instance.Position.Extend(Events.LastHarassPos, Spells.E.Range - 1).To3DWorld());
                        }, (365 - Game.Ping));
                    }
                    break;
                case "Agressive Mode":
                    var qtarget = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    if (qtarget == null || !qtarget.IsValidTarget()) return;
                    
                    if (Spells.Q.IsReady() && Settings.harras_q )
                    {
                        Spells.Q.Cast(qtarget);
                    }
                    if (Spells.E.IsReady() && Settings.harras_e)
                    {
                        Spells.E.Cast(qtarget);
                    }
                    if (Events.MyDic.ContainsKey(qtarget))
                    {
                        Events.MyDic[qtarget]++;
                    }
                    if (Events.MyDic.ContainsKey(qtarget) && Events.MyDic[qtarget] >= Game.TicksPerSecond * 2 && Settings.combo_ww && Spells.W.IsReady() && Settings.combo_w)
                    {
                        Spells.W.Cast();
                        Orbwalker.ResetAutoAttack();
                    }
                    break;

            }
        }
    }
}