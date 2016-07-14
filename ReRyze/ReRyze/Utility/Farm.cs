using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Enumerations;
using ReRyze.ConfigList;

namespace ReRyze.Utility
{
    public static class Farm
    {
        public static void Execute()
        {
            if (Environment.TickCount - SpellManager.LastLaneClear < Misc.GetSpellDelay + 500)
                return;

            var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
            if (target.Count() == 0)
                target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));

            int delay = Misc.GetSpellDelay + Damage.GetAditionalDelay();
            if (ConfigList.Farm.FarmE && SpellManager.E.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearE_Mana)
            {
                var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
                var monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));
                if ((minions.Count() + monsters.Count()) == 0)
                    return;

                target = monsters;
                if (monsters.Count() == 0)
                    target = minions;

                if (target == null)
                    return;

                if (minions.Count() >= ConfigList.Farm.FarmECount || (monsters.Count() > 0 && ConfigList.Farm.FarmEIgnore))
                {
                    Core.DelayAction(() => SpellManager.E.Cast(target.FirstOrDefault()), delay);
                    SpellManager.LaneClearStep++;
                    SpellManager.LastLaneClear = Environment.TickCount;
                }
            }
            if (ConfigList.Farm.FarmQ && SpellManager.Q.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearQ_Mana && SpellManager.LaneClearStep >= 2)
            {
                var unit = target.FirstOrDefault();
                if (unit.TotalShieldHealth() <= Damage.GetQDamage(unit) || unit.TotalShieldHealth() / Damage.GetQDamage(unit) > 2)
                {
                    var predQ = SpellManager.Q.GetPrediction(unit);
                    if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.LaneClearMinToUseQ))
                    {
                        Core.DelayAction(() => SpellManager.Q.Cast(predQ.CastPosition), delay*2);
                        SpellManager.LaneClearStep = 0;
                    }
                }
            }
        }
    }
}
