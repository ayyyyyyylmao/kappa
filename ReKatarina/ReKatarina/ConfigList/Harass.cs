using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Harass
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _HarassWithQ;
        private static readonly CheckBox _HarassWithW;

        public static bool HarassWithQ
        {
            get { return _HarassWithQ.CurrentValue; }
        }
        public static bool HarassWithW
        {
            get { return _HarassWithW.CurrentValue; }
        }

        static Harass()
        {
            Menu = Config.Menu.AddSubMenu("Harass");
            Menu.AddGroupLabel("Harass settings");
            _HarassWithQ = Menu.Add("HarasWithQ", new CheckBox("Enable auto Q in harass mode."));
            _HarassWithW = Menu.Add("HarasWithW", new CheckBox("Enable auto W in harass mode."));
        }

        public static void Initialize()
        {
        }
    }
}