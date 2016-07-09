using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReGaren.Utility
{
    public static class Farm
    {
        public static void Execute()
        {
            int minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.E.Range)).Count();
            int monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.E.Range * 2)).Count();
            if ((minions + monsters) == 0)
                return;

            if (ConfigList.Farm.FarmQ && SpellManager.Q.IsReady())
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range * 2));
                if (target != null)
                {
                    foreach (var select in target)
                    {
                        if (select.IsValidTarget(SpellManager.E.Range) && select.Health < Damage.GetQDamage(select))
                        {
                            SpellManager.Q.Cast();
                            Player.IssueOrder(GameObjectOrder.AttackUnit, select);
                            return;
                        }
                    }
                }
                else if (Player.Instance.IsUnderEnemyturret())
                {
                    SpellManager.Q.Cast();
                }
            }
            if (ConfigList.Farm.FarmE && SpellManager.E.IsReady())
            {
                if (minions + monsters >= ConfigList.Farm.FarmECount)
                    SpellManager.E.Cast();
            }
        }
    }
}
