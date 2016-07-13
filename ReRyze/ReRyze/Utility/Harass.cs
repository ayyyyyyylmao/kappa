using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class Harass
    {
        public static void Execute()
        {
            if (!SpellManager.Q.IsReady() || !SpellManager.Q.IsLearned || !ConfigList.Harass.HarassWithQ)
                return;

            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            var predQ = SpellManager.Q.GetPrediction(target);
            if (predQ.HitChance >= ConfigList.ChanceHit.GetHitChance(ConfigList.ChanceHit.HarassMinToUseQ))
            {
                SpellManager.Q.Cast(predQ.CastPosition);
            }
        }
    }
}