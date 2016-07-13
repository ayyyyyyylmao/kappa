using EloBuddy.SDK.Menu;
using ReRyze.ConfigList;

namespace ReRyze
{
    public static class Config
    {
        public static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu("ReGaren", "ReGaren");
            Menu.AddGroupLabel("Welcome to ReGaren! It's my first addon, be patient.");
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
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }
        }
    }
}