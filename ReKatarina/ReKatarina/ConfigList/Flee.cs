﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReKatarina.ConfigList
{
    public static class Flee
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _JumpToAlly;
        private static readonly CheckBox _JumpToAllyMinion;
        private static readonly CheckBox _JumpToEnemyMinion;
        private static readonly CheckBox _JumpToMonster;
        private static readonly Slider _JumpToMonsterHP;
        private static readonly CheckBox _JumpToWard;
        private static readonly CheckBox _EnableWards;
        private static readonly Slider _JumpCursorRange;

        public static bool JumpToAlly { get { return _JumpToAlly.CurrentValue; } }
        public static bool JumpToAllyMinion { get { return _JumpToAllyMinion.CurrentValue; } }
        public static bool JumpToEnemyMinion { get { return _JumpToEnemyMinion.CurrentValue; } }
        public static bool JumpToMonster { get { return _JumpToMonster.CurrentValue; } }
        public static int JumpToMonsterHP { get { return _JumpToMonsterHP.CurrentValue; } }
        public static bool EnableWards { get { return _EnableWards.CurrentValue; } }
        public static int JumpCursorRange { get { return _JumpCursorRange.CurrentValue; } }
        

        static Flee()
        {
            Menu = Config.Menu.AddSubMenu("Flee");
            Menu.AddGroupLabel("Flee settings");
            _JumpToAlly = Menu.Add("JumpToAlly", new CheckBox("Enable jump to ally."));
            _JumpToAllyMinion = Menu.Add("JumpToAllyMinion", new CheckBox("Enable jump to ally minion."));
            _JumpToEnemyMinion = Menu.Add("JumpToEnemyMinion", new CheckBox("Enable jump to enemy minion."));
            _JumpToMonster = Menu.Add("JumpToMonster", new CheckBox("Enable jump to monster."));
            _JumpToMonsterHP = Menu.Add("JumpToMonsterHP", new Slider("Enable jump to monster when HP is more than (percents).", 15, 1, 100));
            _EnableWards = Menu.Add("EnableWards", new CheckBox("Enable jump to wards."));
            _JumpCursorRange = Menu.Add("JumpCursorRange", new Slider("Jump to cursor target detect range. ", 200, 100, 250));
        }

        public static void Initialize()
        {
        }
    }
}