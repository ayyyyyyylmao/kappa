using EloBuddy;
using EloBuddy.SDK;
using ReRyze.ConfigList;
using System;

namespace ReRyze.Utility
{
    public static class Combo
    {
        public static void Execute()
        {
            if (Environment.TickCount - SpellManager.LastCombo < Game.Ping*2)
                return;

            var target = TargetSelector.GetTarget(SpellManager.Q.Range - 50, DamageType.Magical);
            if (target == null || !target.IsValid)
                return;

            int delay = ConfigList.Misc.GetSpellDelay;
            if (ConfigList.Combo.SmartCombo)
            {
                if (SpellManager.Q.IsReady())
                {
                    var predQ = SpellManager.Q.GetPrediction(target);
                    if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.ComboMinToUseQ))
                        SpellManager.Q.Cast(predQ.CastPosition);
                }
                if (SpellManager.W.IsReady() && !SpellManager.Q.IsReady() && !SpellManager.E.IsReady())
                    SpellManager.W.Cast(target);
                
                if (SpellManager.E.IsReady() && !SpellManager.Q.IsReady() && !Player.Instance.HasBuff("RyzeQIconFullCharge"))
                    SpellManager.E.Cast(target);
            }
            else
            {
                if (SpellManager.ComboStep >= 8)
                    SpellManager.ComboStep = 0;

                switch (ConfigList.Combo.GetComboLogic == 1 ? SpellManager.ComboMode2[SpellManager.ComboStep] : SpellManager.ComboMode1[SpellManager.ComboStep])
                {
                    case 0:
                        {
                            if (!SpellManager.Q.IsReady())
                            {
                                if (ConfigList.Combo.ComboWithoutQ)
                                    SpellManager.ComboStep++;
                                break;
                            }

                            var predQ = SpellManager.Q.GetPrediction(target);
                            if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.ComboMinToUseQ))
                            {
                                SpellManager.Q.Cast(predQ.CastPosition);
                                SpellManager.ComboStep++;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (!Player.Instance.IsInRange(target, SpellManager.W.Range))
                                break;
                            if (!SpellManager.W.IsReady())
                            {
                                if (ConfigList.Combo.ComboWithoutW)
                                    SpellManager.ComboStep++;
                                break;
                            }
                            Core.DelayAction(() => SpellManager.W.Cast(target), delay);
                            SpellManager.ComboStep++;
                            break;
                        }
                    case 2:
                        {
                            if (!Player.Instance.IsInRange(target, SpellManager.E.Range))
                                break;
                            if (!SpellManager.E.IsReady())
                            {
                                if (ConfigList.Combo.ComboWithoutE)
                                    SpellManager.ComboStep++;
                                break;
                            }
                            Core.DelayAction(() => SpellManager.E.Cast(target), delay / 2);
                            SpellManager.ComboStep++;
                            break;
                        }
                }
            }

            SpellManager.LastCombo = Environment.TickCount;
        }
    }
}
