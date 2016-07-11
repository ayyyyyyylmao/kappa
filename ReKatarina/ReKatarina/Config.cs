using EloBuddy.SDK.Menu;
using ReKatarina.ConfigList;

namespace ReKatarina
{
    public static class Config
    {
        public static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu("ReKatarina", "ReKatarina");
            Menu.AddGroupLabel("Welcome to ReKatarina! It's my second addon, be patient.");
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            static Modes()
            {
                // Menu
                Combo.Initialize();
                Drawing.Initialize();
                Farm.Initialize();
                Harass.Initialize();
                Flee.Initialize();
                WardJump.Initialize();
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }
        }
    }
}