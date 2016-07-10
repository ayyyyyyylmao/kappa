using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Flee
    {
        private static readonly Menu Menu;

        static Flee()
        {
            Menu = Config.Menu.AddSubMenu("Flee");
            Menu.AddGroupLabel("Flee settings");
        }

        public static void Initialize()
        {
        }
    }
}