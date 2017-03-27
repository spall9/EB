using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz
{
    class Events
    {
        public static Vector3 LastHarassPos { get; set; }
        public static bool JumpBack { get; set; }
        public static Dictionary<AIHeroClient, int> MyDic = new Dictionary<AIHeroClient, int>();
         public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe)
                return;

            if (args.SData.Name == "FizzQ" && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                Core.DelayAction(() =>
                    {
                        JumpBack = true;
                    }, (int)(sender.Spellbook.CastEndTime - Game.Time) + Game.Ping / 2 + 250);

            if (args.SData.Name == "FizzETwo")
            {
                LastHarassPos = Vector3.Zero;
                JumpBack = false;
            }
        }
        public static void Obj_AI_BaseOnBuffgain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {

            var hero = sender as AIHeroClient;
            if (hero == null || !args.Buff.Name.Equals("fizzwdot")) return;
            if (!MyDic.ContainsKey(hero))
            {
                MyDic.Add(hero, 0);
            }
        }

       public static void Obj_AI_BaseOnBufflose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || !args.Buff.Name.Equals("fizzwdot")) return;
            if (MyDic.ContainsKey(hero))
            {
                MyDic.Remove(hero);
            }

        }
      public  static void OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender is Obj_AI_Turret && args.Target.IsMe && Spells.E.IsReady() && Fmeniu.autoe)
            {
                if (Fmeniu.autoe)
                {
                    Spells.E.Cast(Player.Instance.Position.Extend(Game.CursorPos, Spells.E.Range - 1).To3DWorld());
                    Core.DelayAction(() =>
                    {
                        Spells.E.Cast(Player.Instance.Position.Extend(Game.CursorPos, Spells.E.Range - 1).To3DWorld());
                    }, (365 - Game.Ping));
                }
            }
        }
       public static void OnDraw(EventArgs args)
        {
            if (Fmeniu.DrawQ)
                Circle.Draw(Spells.Q.IsReady() ? Color.Blue : Color.Red,
                    Spells.Q.Range, 3F, Player.Instance.Position);

            if (Fmeniu.DrawW)
                Circle.Draw(Spells.W.IsReady() ? Color.Purple : Color.Red,
                    Spells.W.Range, 3F, Player.Instance.Position);

            if (Fmeniu.DrawE)
                Circle.Draw(Spells.E.IsReady() ? Color.SeaGreen : Color.Red,
                    Spells.E.Range, 3F, Player.Instance.Position);

            if (Fmeniu.DrawR)
                Circle.Draw(Spells.R.IsReady() ? Color.Yellow : Color.Red,
                    Spells.R.Range, 3F, Player.Instance.Position);

        }
    }
}
