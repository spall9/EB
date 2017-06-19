using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using UnsignedEvade; // Credit to Chaos for logic if about to be hit and his spelldatabase

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
                GameObject.OnCreate += Events.OnCreate;
                GameObject.OnDelete += Events.OnDelete;
                Obj_AI_Base.OnUpdatePosition += Events.OnUpdate;

                foreach (AIHeroClient client in EntityManager.Heroes.Enemies)
                {
                    foreach (SpellInfo info in SpellDatabase.SpellList)
                    {
                        if (info.ChampionName == client.ChampionName)
                        {
                            logic.Wlogic.EnemyProjectileInformation.Add(info);

                        }
                    }
                }
            }

        }

    }
}