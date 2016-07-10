using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class WardJump
    {
        private static readonly Menu Menu;

        static WardJump()
        {
            Menu = Config.Menu.AddSubMenu("Wardjump");
            Menu.AddGroupLabel("Wardjump settings");
        }

        public static void Initialize()
        {
        }
    }
}