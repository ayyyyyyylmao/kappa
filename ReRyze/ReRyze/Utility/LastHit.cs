using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;
using ReRyze.ConfigList;

namespace ReRyze.Utility
{
    public static class LastHit
    {
        public static void Execute()
        {
            if (ConfigList.Farm.FarmQLastHit && SpellManager.Q.IsReady() && Player.Instance.ManaPercent >= ManaManager.LastHitQ_Mana)
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
                if (target.Count() == 0)
                    target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));

                if (target != null)
                {
                    foreach (var select in target)
                    {
                        if (select.IsValidTarget(SpellManager.Q.Range) && select.TotalShieldHealth() < Damage.GetQDamage(select))
                        {
                            var predQ = SpellManager.Q.GetPrediction(select);
                            if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.LaneClearMinToUseQ))
                                Core.DelayAction(() => SpellManager.Q.Cast(predQ.CastPosition), Misc.GetSpellDelay + Damage.GetAditionalDelay());
                            return;
                        }
                    }
                }
            }
        }
    }
}
