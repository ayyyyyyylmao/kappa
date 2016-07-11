using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReKatarina.Utility
{
    public static class LastHit
    {
        public static void Execute()
        {
            if (ConfigList.Farm.LastHitQ && SpellManager.Q.IsReady())
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
                if (target.Count() == 0)
                    target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));

                if (target != null)
                {
                    foreach (var select in target)
                    {
                        if (select.IsValidTarget(SpellManager.Q.Range) && select.TotalShieldHealth() <= Damage.GetQDamage(select))
                        {
                            Core.DelayAction(() => SpellManager.Q.Cast(select), ConfigList.Misc.GetSpellDelay);
                            return;
                        }
                    }
                }
            }
            if (ConfigList.Farm.LastHitW && SpellManager.W.IsReady())
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.W.Range));
                if (target.Count() == 0)
                    target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.W.Range));

                if (target != null)
                {
                    foreach (var select in target)
                    {
                        if (select.IsValidTarget(SpellManager.W.Range) && select.TotalShieldHealth() <= Damage.GetWDamage(select))
                        {
                            Core.DelayAction(() => SpellManager.W.Cast(), ConfigList.Misc.GetSpellDelay + Game.Ping);
                            return;
                        }
                    }
                }
            }
        }
    }
}
