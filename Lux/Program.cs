using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lux
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (ObjectManager.Player.ChampionName == "Lux")
            {
                Meniu.ini();
                Chat.Print("Lux loaded");
                Spells.Ini();
                Game.OnTick += Events.Game_OnTick;
                AIHeroClient.OnProcessSpellCast += Events.AIHeroClient_OnProcessSpellCast;
                AIHeroClient.OnBasicAttack += Events.AIHeroClient_OnBasicAttack;
            }

        }


    }
}