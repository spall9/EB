using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace Tamh_kench
{
    class Perma : Tahm_menu
    {
        public static void Permactive()
        {
            if (Spells.E.IsReady() && Extension.GetCheckBoxValue(ComboMenu, "Combo.E")&&
                ObjectManager.Player.HealthPercent <= Extension.GetSliderValue(ComboMenu,"Combo.E.Hp") &&
                Extensions.CountEnemyChampionsInRange(Player.Instance.Position, 900) >= 1)
            {
                Spells.E.Cast();
            }
            if (Extension.GetCheckBoxValue(SaveMenu, "enableSaving") && !Extension.Swallowed &&
                Spells.WSwallow.IsReady())
            {
                var allytosave =
                    EntityManager.Allies.FirstOrDefault(
                        ally =>
                            !ally.IsMe && !ally.IsMinion && !ally.IsDead &&
                            ally.HealthPercent <= Extension.GetSliderValue(SaveMenu, "save.allies.hp") &&
                            ObjectManager.Player.Distance(ally) < 500);
                if (allytosave != null)
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo, allytosave.ServerPosition);
                    Spells.WSwallow.Cast(allytosave);

                }
            }
        }
    }
}

