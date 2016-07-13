using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class PermaActive
    {
        private static bool chance(int chance)
        {
            if (Damage.getrandom.Next(0, 100) <= chance)
                return true;
            return false;
        }
        public static void Execute()
        {
            // Auto range update
            if (SpellManager.R.Level >= 2 && SpellManager.R.Range == Damage.UltimateRange[0])
                SpellManager.R.Range = (uint)Damage.UltimateRange[1];

            // Skin manager
            if (ConfigList.Misc.GetSkinManagerStatus && Player.Instance.SkinId != ConfigList.Misc.GetSkinManager)
            {
                Player.Instance.SetSkinId(ConfigList.Misc.GetSkinManager);
            }

            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target != null && target.IsValid())
            {
                // Auto KS 
                if (SpellManager.Q.IsReady() && ConfigList.Misc.KSWithQ && Damage.GetQDamage(target) - 5 >= target.TotalShieldHealth())
                {
                    var predQ = SpellManager.Q.GetPrediction(target);
                    if (predQ.HitChance >= HitChance.Medium)
                    {
                        SpellManager.Q.Cast(predQ.CastPosition); return;
                    }
                }
                if (SpellManager.W.IsReady() && ConfigList.Misc.KSWithW && Damage.GetWDamage(target) - 5 >= target.TotalShieldHealth())
                {
                    SpellManager.W.Cast(target); 
                    return;
                }
                if (SpellManager.E.IsReady() && ConfigList.Misc.KSWithE && Damage.GetEDamage(target) - 5 >= target.TotalShieldHealth())
                    SpellManager.E.Cast(target);

                // Auto harass
                if (!ConfigList.Harass.AutoHarassUnderTurret && Player.Instance.IsUnderEnemyturret() && target.IsUnderHisturret())
                    return;

                if (!chance(ConfigList.Harass.AutoHarassChance))
                    return;

                if (SpellManager.Q.IsReady() && ConfigList.Harass.AutoHarassWithQ && Player.Instance.ManaPercent >= ConfigList.ManaManager.AutoHarassQ_Mana)
                {
                    var predQ = SpellManager.Q.GetPrediction(target);
                    if (predQ.HitChance >= ConfigList.ChanceHit.GetHitChance(ConfigList.ChanceHit.AutoHarassMinToUseQ))
                    {
                        SpellManager.Q.Cast(predQ.CastPosition); return;
                    }
                }
            }
        }
    }
}
