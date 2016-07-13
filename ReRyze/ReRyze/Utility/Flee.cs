using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class Flee
    {
        public static void Execute()
        {
            if (!SpellManager.W.IsReady() || !SpellManager.W.IsLearned || !ConfigList.Misc.FleeWithW)
                return;

            var target = TargetSelector.GetTarget(SpellManager.W.Range, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            SpellManager.W.Cast(target);
        }
    }
}
