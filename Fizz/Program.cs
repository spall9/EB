using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Fizz.Modes;
using SharpDX;
using EloBuddy.SDK.Rendering;
using DrawSettings = Fizz.Fmeniu;
using EloBuddy.SDK.Menu.Values;
namespace Fizz
{
    class Program
    {
        public static int SkinID = 0;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Fizz")
            {
                return;
            }
            {
                Chat.Print("Fizz By modziux Successfully loaded Have fun :)",System.Drawing.Color.DeepSkyBlue);
                Fmeniu.Loadmenu();
                Spells.FSpellsloud();
                modesmanager.ModeManager();
                Obj_AI_Base.OnBuffGain += Events.Obj_AI_BaseOnBuffgain;
                Obj_AI_Base.OnBuffLose += Events.Obj_AI_BaseOnBufflose;
                Obj_AI_Base.OnBasicAttack += Events.OnBasicAttack;
                Obj_AI_Base.OnProcessSpellCast += Events.OnProcessSpellCast;
                Drawing.OnDraw += Events.OnDraw;
                SkinID = Player.Instance.SkinId;
            }



        }
    }
}
