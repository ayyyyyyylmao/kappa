using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Harass
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _HarassWithQ;
        private static readonly CheckBox _HarassWithW;
        private static readonly CheckBox _AutoHarassWithQ;
        private static readonly CheckBox _AutoHarassWithW;
        private static readonly Slider _AutoHarassChance;

        public static bool HarassWithQ
        {
            get { return _HarassWithQ.CurrentValue; }
        }
        public static bool HarassWithW
        {
            get { return _HarassWithW.CurrentValue; }
        }
        public static bool AutoHarassWithQ
        {
            get { return _AutoHarassWithQ.CurrentValue; }
        }
        public static bool AutoHarassWithW
        {
            get { return _AutoHarassWithW.CurrentValue; }
        }
        public static int AutoHarassChance
        {
            get { return _AutoHarassChance.CurrentValue; }
        }

        static Harass()
        {
            Menu = Config.Menu.AddSubMenu("Harass");
            Menu.AddGroupLabel("Harass settings");
            _HarassWithQ = Menu.Add("HarasWithQ", new CheckBox("Enable Q in harass mode."));
            _HarassWithW = Menu.Add("HarasWithW", new CheckBox("Enable W in harass mode."));
            Menu.AddGroupLabel("Auto-harass settings");
            _AutoHarassWithQ = Menu.Add("AutoHarassWithQ", new CheckBox("Enable auto harass with Q."));
            _AutoHarassWithW = Menu.Add("AutoHarassWithW", new CheckBox("Enable auto harass with W."));
            _AutoHarassChance = Menu.Add("AutoHarassChance", new Slider("Auto harass chance.", 50, 1, 100));
        }

        public static void Initialize()
        {
        }
    }
}