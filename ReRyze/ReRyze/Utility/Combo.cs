using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using ReRyze.ConfigList;

namespace ReRyze.Utility
{
    public static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range - 50, DamageType.Magical, Player.Instance.Position);
            if (target == null || !target.IsValidTarget())
                return;

            int delay = ConfigList.Misc.GetSpellDelay + Damage.GetAditionalDelay();
            if (SpellManager.ComboStep >= 8)
                SpellManager.ComboStep = 0;

            switch (ConfigList.Combo.GetComboLogic == 1 ? SpellManager.ComboMode2[SpellManager.ComboStep] : SpellManager.ComboMode1[SpellManager.ComboStep])
            {
                case 0:
                    {
                        if (!SpellManager.Q.IsReady())
                            break;

                        var predQ = SpellManager.Q.GetPrediction(target);
                        if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.ComboMinToUseQ))
                        {
                            SpellManager.Q.Cast(predQ.CastPosition);
                            SpellManager.ComboStep++;
                            SpellManager.LastCombo = Environment.TickCount;
                        }
                        break;
                    }
                case 1:
                    {
                        if (!SpellManager.W.IsReady() && ConfigList.Combo.ComboWithoutW)
                        {
                            SpellManager.ComboStep++;
                            SpellManager.LastCombo = Environment.TickCount;
                            break;
                        }
                        if (!Player.Instance.IsInRange(target, SpellManager.W.Range))
                            break;

                        Core.DelayAction(() => SpellManager.W.Cast(target), delay);
                        SpellManager.ComboStep++;
                        SpellManager.LastCombo = Environment.TickCount;
                        break;
                    }
                case 2:
                    {
                        if (!SpellManager.E.IsReady() || !Player.Instance.IsInRange(target, SpellManager.E.Range))
                            break;

                        Core.DelayAction(() => SpellManager.E.Cast(target), delay * 2);
                        SpellManager.ComboStep++;
                        SpellManager.LastCombo = Environment.TickCount;
                        break;
                    }
            }
            return;
        }
    }
}
