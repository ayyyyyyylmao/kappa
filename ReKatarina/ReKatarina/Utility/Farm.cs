using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;

namespace ReKatarina.Utility
{
    public static class Farm
    {
        public static void Execute()
        {
            if (ConfigList.Farm.FarmW && SpellManager.W.IsReady())
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.W.Range * 2));
                if (target.Count() == 0)
                    target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.W.Range * 2));

                if (target == null)
                    return;

                var unit = target.FirstOrDefault();
                if (unit.Health <= Damage.GetWDamage(unit) || unit.Health / Damage.GetWDamage(unit) > 2)
                    SpellManager.W.Cast();
            }
            if (ConfigList.Farm.FarmQ && SpellManager.Q.IsReady())
            {
                var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
                var monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));
                if ((minions.Count() + monsters.Count()) == 0)
                    return;

                var target = monsters;
                if (monsters.Count() == 0)
                    target = minions;

                if (target == null)
                    return;

                if (minions.Count() >= ConfigList.Farm.FarmQCount || (monsters.Count() > 0 && ConfigList.Farm.FarmQIgnore))
                    Core.DelayAction(() => SpellManager.Q.Cast(target.FirstOrDefault()), ConfigList.Misc.GetSpellDelay + Damage.GetAditionalDelay());
            }
        }
    }
}
