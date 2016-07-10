using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Farm
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _FarmQ;
        private static readonly CheckBox _FarmW;
        private static readonly Slider _FarmQCount;
        private static readonly CheckBox _IgnoreQCountJng;

        public static bool FarmQ
        {
            get { return _FarmQ.CurrentValue; }
        }
        public static bool FarmW
        {
            get { return _FarmW.CurrentValue; }
        }
        public static int FarmQCount
        {
            get { return _FarmQCount.CurrentValue; }
        }
        public static bool FarmQIgnore
        {
            get { return _IgnoreQCountJng.CurrentValue; }
        }

        static Farm()
        {
            Menu = Config.Menu.AddSubMenu("Farm");
            Menu.AddGroupLabel("Farm settings");
            _FarmQ = Menu.Add("FarmQ", new CheckBox("Use Q in lane / jugnle clear."));
            _FarmW = Menu.Add("FarmW", new CheckBox("Use W in lane / jugnle clear."));
            Menu.AddSeparator();
            _IgnoreQCountJng = Menu.Add("IgnoreQCountJng", new CheckBox("Ignore Q count in jungle clear."));
            _FarmQCount = Menu.Add("FarmQCount", new Slider("Use Q if creeps count", 3, 1, 5));
        }

        public static void Initialize()
        {
        }
    }
}