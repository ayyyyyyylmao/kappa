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
                    Core.DelayAction(() => SpellManager.E.Cast(target), delay);

            if (ConfigList.Combo.ComboW && !Damage.HasRBuff())
                if (SpellManager.W.IsReady() && Player.Instance.IsInRange(target, SpellManager.W.Range))
                    Core.DelayAction(() => SpellManager.W.Cast(), (int)(delay * 1.5));

            if (ConfigList.Combo.ComboR && Player.Instance.CountEnemiesInRange(SpellManager.R.Range) >= ConfigList.Combo.MinToUseR)
                if (SpellManager.R.IsReady() && Player.Instance.IsInRange(target, SpellManager.R.Range))
                {
                    if (Player.Instance.CountEnemiesInRange(SpellManager.R.Range) == 1 && (Damage.GetQDamage(target) + Damage.GetWDamage(target) + Damage.GetEDamage(target)) < target.TotalShieldHealth())
                    {
                        Core.DelayAction(() => Damage.UnfreezePlayer(), 2500);
                        Core.DelayAction(() => SpellManager.R.Cast(), (int)(delay*1.75));
                        Core.DelayAction(() => Damage.FreezePlayer(), (int)(delay*1.75));
                    }
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