using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using System;
using System.Linq;

namespace ReKatarina.Utility
{
    public static class Flee
    {
        public static void Execute()
        {
            if (!SpellManager.E.IsReady() || Damage.HasRBuff())
                return;

            if (ConfigList.Flee.JumpToAlly)
            {
                var farthest = EntityManager.Heroes.Allies.OrderBy(a => a.CountEnemiesInRange(SpellManager.E.Range)).ThenByDescending(a => a.Distance(Player.Instance)).FirstOrDefault(a => a.IsValidTarget(SpellManager.E.Range) && !a.IsMe);
                if (farthest != null)
                {
                    SpellManager.E.Cast(farthest);
                    return;
                }
            }
            if (ConfigList.Flee.JumpToAllyMinion)
            {
                var farthest = EntityManager.MinionsAndMonsters.Minions.OrderBy(a => a.CountAllyMinionsInRange(SpellManager.E.Range)).ThenByDescending(a => a.Distance(Player.Instance)).FirstOrDefault(a => a.IsValidTarget(SpellManager.E.Range) && !a.IsMe);
                if (farthest != null)
                {
                    SpellManager.E.Cast(farthest);
                    return;
                }
            }
            if (ConfigList.Flee.JumpToMonster && (EloBuddy.Player.Instance.HealthPercent >= (float)ConfigList.Flee.JumpToMonsterHP))
            {
                var farthest = EntityManager.MinionsAndMonsters.Monsters.OrderBy(a => EntityManager.MinionsAndMonsters.Monsters.Where(b => b.IsInRange(b, SpellManager.E.Range)).Count()).ThenByDescending(a => a.Distance(Player.Instance)).FirstOrDefault(a => a.IsValidTarget(SpellManager.E.Range) && !a.IsMe);
                if (farthest != null)
                {
                    SpellManager.E.Cast(farthest);
                    return;
                }
            }
            if (ConfigList.Flee.EnableWards)
            {

            }
            if (ConfigList.Flee.EnablePinks)
            {

            }
        }
    }
}
