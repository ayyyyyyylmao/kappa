using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReKatarina.Utility
{
    public static class Harass
    {
        public static void Execute()
        {
            if (!SpellManager.Q.IsReady() || !ConfigList.Harass.HarassWithQ)
                return;

            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Mixed, Player.Instance.Position);
            if (target != null)
            {
                Core.DelayAction(() => SpellManager.Q.Cast(target), ConfigList.Misc.GetSpellDelay);
                if (Player.Instance.IsInRange(target, SpellManager.W.Range) && ConfigList.Harass.HarassWithW)
                    Core.DelayAction(() => SpellManager.W.Cast(), ConfigList.Misc.GetSpellDelay + Damage.GetAditionalDelay());
            }
        }
    }
}
