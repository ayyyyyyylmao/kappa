using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class ManaManager
    {
        private static readonly Menu Menu;
        private static readonly Slider _LCUseQ; // lane clear min mana to use q
        private static readonly Slider _LCUseE;

        private static readonly Slider _LHUseQ;

        static ManaManager()
        {
            Menu = Config.Menu.AddSubMenu("Mana manager");
            Menu.AddGroupLabel("Mana manager settings");
            Menu.AddSeparator(15);
            Menu.AddGroupLabel("Lane / jungle clear");
            _LCUseQ = Menu.Add("LCUseQ", new Slider("Min. mana to use Q", 50, 1, 100));
            _LCUseE = Menu.Add("LCUseW", new Slider("Min. mana to use W", 50, 1, 100));

            Menu.AddGroupLabel("Last hit");
            _LHUseQ = Menu.Add("LHUseQ", new Slider("Min. mana to use Q", 65, 1, 100));
        }

        public static void Initialize()
        {
        }
    }
}