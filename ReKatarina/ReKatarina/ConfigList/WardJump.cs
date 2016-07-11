using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class WardJump
    {
        private static readonly Menu Menu;
        private static readonly KeyBind _WardJumpKey;
        private static readonly CheckBox _WardingTotem;
        private static readonly Slider _WardingTotemSaver;
        private static readonly CheckBox _VisionWard;
        private static readonly CheckBox _TrackersKnife;
        private static readonly CheckBox _Sightstone;
        private static readonly CheckBox _RubySightstone;
        private static readonly CheckBox _EyeoftheWatchers;
        private static readonly CheckBox _EyeoftheOasis;
        private static readonly CheckBox _EyeoftheEquinox;

        public static bool WardJumpKey { get { return _WardJumpKey.CurrentValue; } }
        public static bool UseWardingTotem { get { return _WardingTotem.CurrentValue; } }
        public static int WardingTotemSaver { get { return _WardingTotemSaver.CurrentValue; } }
        public static bool UseVisionWard { get { return _VisionWard.CurrentValue; } }
        public static bool UseTrackersKnife { get { return _TrackersKnife.CurrentValue; } }
        public static bool UseSightstone { get { return _Sightstone.CurrentValue; } }
        public static bool UseRubySightstone { get { return _RubySightstone.CurrentValue; } }
        public static bool UseEyeoftheWatchers { get { return _EyeoftheWatchers.CurrentValue; } }
        public static bool UseEyeoftheOasis { get { return _EyeoftheOasis.CurrentValue; } }
        public static bool UseEyeoftheEquinox { get { return _EyeoftheEquinox.CurrentValue; } }

        static WardJump()
        {
            Menu = Config.Menu.AddSubMenu("Wardjump");
            Menu.AddGroupLabel("Wardjump settings");
            _WardJumpKey = Menu.Add("WardJumpKey", new KeyBind("WardJump key", false, KeyBind.BindTypes.HoldActive, 'Y'));

            Menu.AddGroupLabel("Normal wards");
            _WardingTotem = Menu.Add("WardingTotem", new CheckBox("Use Warding Totem"));
            _WardingTotemSaver = Menu.Add("WardingTotemSaver", new Slider("Warding Totem keep at", 1, 0, 2));
            _VisionWard = Menu.Add("VisionWard", new CheckBox("Use Vision Ward"));

            Menu.AddGroupLabel("Jungle wards");
            _TrackersKnife = Menu.Add("TrackersKnife", new CheckBox("Use Tracker's Knife"));

            Menu.AddGroupLabel("Support wards");
            _Sightstone = Menu.Add("Sightstone", new CheckBox("Use Sightstone"));
            _RubySightstone = Menu.Add("RubySightstone", new CheckBox("Use Ruby Sightstone"));
            _EyeoftheWatchers = Menu.Add("EyeoftheWatchers", new CheckBox("Eye of the Watchers"));
            _EyeoftheOasis = Menu.Add("EyeoftheOasis", new CheckBox("Use Eye of the Oasis"));
            _EyeoftheEquinox = Menu.Add("EyeoftheEquinox", new CheckBox("Use Eye of the Equinox"));
        }

        public static void Initialize()
        {
        }
    }
}