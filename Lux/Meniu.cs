using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;

namespace lux
{
    class Meniu
    {
        public static Menu Menu, Combo, Harras, Laneclear, Jungleclear, Misc;
        public static void ini()
        {
             Menu = MainMenu.AddMenu("Lux", "luxe");
            Menu.AddGroupLabel("Lux By Modziux");
            Combo = Menu.AddSubMenu("Combo", "combolux");
            Combo.Add("combo.q", new CheckBox("Use Q"));
            Combo.AddSeparator();
            Combo.Add("combo.e", new CheckBox("Use E"));
            Combo.Add("combo.e.enemies", new Slider("Min enemies hit", 1, 1, 5));
            Combo.AddSeparator();
            Combo.Add("combo.r", new CheckBox("Use R"));
            Combo.Add("combo.r.logic", new ComboBox("R Logic", 2, "R only on killable", "R only on hit x target", "Both"));
            Combo.Add("combo.r.min", new Slider("Min enemies to use R", 2, 1, 5));
            Harras = Menu.AddSubMenu("Harass", "harassmenu");
            Harras.Add("harass.q", new CheckBox("Use Q"));
            Harras.AddSeparator();
            Harras.Add("harass.e", new CheckBox("Use E"));
            Harras.Add("harass.e.enemies", new Slider("Min enemies hit", 1, 1, 5));
            Laneclear = Menu.AddSubMenu("LaneClear", "Valiklis");
            Laneclear.Add("laneclear.e", new CheckBox("Use E"));
            Laneclear.Add("laneclear.e.min", new Slider("Cast E only if hit x minnion", 3, 1, 10));
            Laneclear.Add("laneclear.q", new CheckBox("Use Q"));
            Misc = Menu.AddSubMenu("Misc", "miscmenu");
            Misc.Add("auto.q", new CheckBox("Auto Q if Can hit 2 Champions"));
            Misc.Add("auto.q.imo", new CheckBox("Auto Q on Imobile target"));
            Misc.AddSeparator();
            Misc.Add("auto.e.min", new Slider("Auto E on X targets", 3, 1, 5));
            Misc.Add("auto.e.imo", new CheckBox("Auto E on Imobile target"));
            Misc.AddSeparator();
            Misc.Add("auto.r", new CheckBox("Auto R on killable"));
        }
    }
}
