using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace LightAmumu.MenuList
{
    public static class Mana
    {
        private static readonly Menu Menu;
        private static readonly Slider _minHarassE;

        private static readonly Slider _minLnW;
        private static readonly Slider _minLnE;

        private static readonly Slider _minJngQ;
        private static readonly Slider _minJngW;
        private static readonly Slider _minJngE;

        // Harass
        public static int minHarassE
        {
            get { return _minHarassE.CurrentValue; }
        }
        // Lane clear
        public static int minLnW
        {
            get { return _minLnW.CurrentValue; }
        }
        public static int minLnE
        {
            get { return _minLnE.CurrentValue; }
        }
        // Jungle clear
        public static int minJngQ
        {
            get { return _minJngQ.CurrentValue; }
        }
        public static int minJngW
        {
            get { return _minJngW.CurrentValue; }
        }
        public static int minJngE
        {
            get { return _minJngE.CurrentValue; }
        }

        static Mana()
        {
            Menu = DrawingMenu.Menu.AddSubMenu("Mana manager");
            Menu.AddGroupLabel("Harass");
            _minHarassE = Menu.Add("minHarassE", new Slider("Min mana to use E in harass mode.", 35, 1, 100));

            Menu.AddGroupLabel("Lane clear");
            _minLnW = Menu.Add("minlW", new Slider("Min mana to use W in lane clear.", 55, 1, 100));
            Menu.AddSeparator();
            _minLnE = Menu.Add("minlE", new Slider("Min mana to use E in lane clear.", 25, 1, 100));

            Menu.AddGroupLabel("Jungle clear");
            _minJngQ = Menu.Add("minjQ", new Slider("Min mana to use Q in jungle clear.", 75, 1, 100));
            Menu.AddSeparator();
            _minJngW = Menu.Add("minjW", new Slider("Min mana to use W in jungle clear.", 55, 1, 100));
            Menu.AddSeparator();
            _minJngE = Menu.Add("minjE", new Slider("Min mana to use E in jungle clear.", 25, 1, 100));
        }

        public static void Initialize()
        {
        }
    }
}