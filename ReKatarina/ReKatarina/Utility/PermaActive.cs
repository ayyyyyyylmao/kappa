using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReKatarina.Utility
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
            // Skin manager
            if (ConfigList.Misc.GetSkinManagerStatus && Player.Instance.SkinId != ConfigList.Misc.GetSkinManager)
            {
                Player.Instance.SetSkinId(ConfigList.Misc.GetSkinManager);
            }

            // Select target 
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical, Player.Instance.Position);
            if (target == null)
                return;

            // Auto KS
            bool KSWithQ = false;
            if (SpellManager.Q.IsReady() && ConfigList.Misc.KSWithQ)
            {
                if (target.TotalShieldHealth() < Damage.GetQDamage(target))
                {
                    KSWithQ = true;
                    SpellManager.Q.Cast(target);
                }
            }
            if (SpellManager.W.IsReady() && ConfigList.Misc.KSWithW)
            {
                if (target.TotalShieldHealth() < Damage.GetWDamage(target) && !KSWithQ)
                {
                    SpellManager.W.Cast();
                }
            }

            // Auto harass
            if (!chance(ConfigList.Harass.AutoHarassChance))
                return;

            bool delayer = false;
            if (SpellManager.Q.IsReady() && ConfigList.Harass.AutoHarassWithQ)
            {
                SpellManager.Q.Cast(target);
                delayer = true;
            }
            if (SpellManager.W.IsReady() && ConfigList.Harass.AutoHarassWithW && Player.Instance.IsInRange(target, SpellManager.W.Range))
            {
                Core.DelayAction(() => SpellManager.W.Cast(), delayer ? (100 + Damage.GetAditionalDelay()) : (0));
            }

        }
    }
}
