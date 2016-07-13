using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class HitChance
    {
        private static readonly Menu Menu;

        static HitChance()
        {
            Menu = Config.Menu.AddSubMenu("Hit chance");
            Menu.AddGroupLabel("Hit chance settings");

        }

        public static void Initialize()
        {
        }
    }
}