using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range - 50, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            if (SpellManager.Q.IsReady())
            {
                var predQ = SpellManager.Q.GetPrediction(target);
                if (predQ.HitChance >= HitChance.Medium)
                {
                    SpellManager.Q.Cast(predQ.CastPosition);
                }
            }
            if (SpellManager.W.IsReady())
            {
                SpellManager.W.Cast(target);
            }
            if (SpellManager.E.IsReady())
            {
                SpellManager.E.Cast(target);
            }
        }
    }
}
