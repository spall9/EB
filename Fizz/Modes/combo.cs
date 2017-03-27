using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;
using Fizz;
using SharpDX;
using Settings = Fizz.Fmeniu;
using Spells = Fizz.Spells;

class combo : Spells
{
    public static void Combo()
    {
        var target = TargetSelector.GetTarget(Spells.R.Range, DamageType.Magical);
        var use_r = (Spells.R.IsReady() && Settings.combo_r);
        var use_e = (Spells.E.IsReady() && Settings.combo_e);
        var use_w = (Spells.W.IsReady() && Settings.combo_w);
        var use_q = (Spells.Q.IsReady() && Settings.combo_q);
        if (target == null) return;
        if (use_q && Spells.Q.IsInRange(target))
        {
            Spells.Q.Cast(target);
        }
        if (Events.MyDic.ContainsKey(target))
        {
            Events.MyDic[target]++;
        }
        if (Events.MyDic.ContainsKey(target) && Events.MyDic[target] >= Game.TicksPerSecond * 2 && Settings.combo_ww && use_w)
        {
            Spells.W.Cast();
            Orbwalker.ResetAutoAttack();
        }
        else if (use_w && Spells.W.IsInRange(target) && !Settings.combo_ww)
        {
            Spells.W.Cast();
            Orbwalker.ResetAutoAttack();
        }
        var prediction = Prediction.Position.PredictUnitPosition(target, 750).Distance(Player.Instance.Position)
                         <= (Spells.E.Range + 200 + 330);
        if (Spells.E.Name == "FizzE" && use_e && !Spells.Q.IsReady() && prediction)
        {
            var castPos = Player.Instance.Distance(Prediction.Position.PredictUnitPosition(target, 750)) > Spells.E.Range
                              ? Player.Instance.Position.Extend(
                                  Prediction.Position.PredictUnitPosition(target, 750),
                                  Spells.E.Range).To3DWorld()
                              : target.Position;

            Spells.E.Cast(castPos);

            var pred2 = Prediction.Position.PredictUnitPosition(target, 750).Distance(Player.Instance.Position)
                        <= (200 + 330 + target.BoundingRadius);

            if (pred2)
            {
                Player.IssueOrder(
                        GameObjectOrder.MoveTo,
                        Prediction.Position.PredictUnitPosition(target, 750).To3DWorld());
            }

            else
            {
                Spells.E.Cast(Prediction.Position.PredictUnitPosition(target, 750).To3DWorld());
            }
        }
        if (use_r && !target.IsZombie)
        {
            CastR(target, Fmeniu.RMode);
        }
    }
}

