using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReRyze.Utility
{
    public static class PermaActive
    {
        public static void Execute()
        {
            // Skin manager
            if (ConfigList.Misc.GetSkinManagerStatus && Player.Instance.SkinId != ConfigList.Misc.GetSkinManager)
            {
                Player.Instance.SetSkinId(ConfigList.Misc.GetSkinManager);
            }

            // Auto KS 
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target != null && target.IsValid())
            {
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
            }
        }
    }
}
