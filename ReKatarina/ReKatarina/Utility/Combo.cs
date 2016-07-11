using System;
using EloBuddy;
using EloBuddy.SDK;

namespace ReKatarina.Utility
{
    public static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Mixed, Player.Instance.Position);
            if (target == null)
                return;

            Combo:
            int delay = ConfigList.Misc.GetSpellDelay + Damage.GetAditionalDelay(); 
            if (ConfigList.Combo.ComboQ && !Damage.HasRBuff())
                if (SpellManager.Q.IsReady() && Player.Instance.IsInRange(target, SpellManager.Q.Range))
                    SpellManager.Q.Cast(target);

            if (ConfigList.Combo.ComboE && Player.Instance.Distance(target) >= SpellManager.W.Range / 2 && !Damage.HasRBuff())
                if (SpellManager.E.IsReady() && Player.Instance.IsInRange(target, SpellManager.E.Range))
                    if (ConfigList.Combo.GoUnderTower)
                        Core.DelayAction(() => SpellManager.E.Cast(target), delay);
                    else
                        if (!target.IsUnderHisturret())
                            Core.DelayAction(() => SpellManager.E.Cast(target), delay);

            if (ConfigList.Combo.ComboW && !Damage.HasRBuff())
                if (SpellManager.W.IsReady() && Player.Instance.IsInRange(target, SpellManager.W.Range))
                    Core.DelayAction(() => SpellManager.W.Cast(), delay * 2);

            if (ConfigList.Combo.ComboR && Player.Instance.CountEnemiesInRange(SpellManager.R.Range) >= ConfigList.Combo.MinToUseR)
                if (SpellManager.R.IsReady() && Player.Instance.IsInRange(target, ConfigList.Combo.MaxRCastRange))
                {
                    if (Player.Instance.CountEnemiesInRange(SpellManager.R.Range) == 1 && (Damage.GetQDamage(target) + Damage.GetWDamage(target) + Damage.GetEDamage(target)) > target.TotalShieldHealth())
                        return;

                    Core.DelayAction(() => Damage.UnfreezePlayer(), 2500);
                    Core.DelayAction(() => SpellManager.R.Cast(), delay * 3);
                    Core.DelayAction(() => Damage.FreezePlayer(), delay * 3);
                }

            // Resets logic 
            if (Damage.HasRBuff() && Player.Instance.CountEnemiesInRange(SpellManager.W.Range) == 0 && SpellManager.R.IsReady() && ConfigList.Combo.ComboR && (Environment.TickCount - SpellManager.LastUltCast) > 1500)
            {
                if (ConfigList.Combo.ComboE && SpellManager.E.IsReady())
                {
                    Damage.UnfreezePlayer();
                    goto Combo;
                }
                    
            }
        }
    }
}