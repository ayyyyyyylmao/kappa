using EloBuddy;
using EloBuddy.SDK;
using ReRyze.ConfigList;
using System;
using System.Linq;

namespace ReRyze.Utility
{
    public static class Farm
    {
        public static void Execute()
        {
            if (Environment.TickCount - SpellManager.LastLaneClear < Game.Ping * 2)
                return;

            int delay = Misc.GetSpellDelay + Damage.GetAditionalDelay();
            if (ConfigList.Farm.FarmQ && SpellManager.Q.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearQ_Mana && (Player.Instance.HasBuff("RyzeQIconFullCharge") || Player.Instance.HasBuff("RyzeQIconNoCharge")))
            {
                var target = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.Q.Range));
                if (target.Count() == 0)
                    target = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.Q.Range));

                var unit = target.FirstOrDefault();
                if (unit.TotalShieldHealth() <= Damage.GetQDamage(unit) || unit.TotalShieldHealth() / Damage.GetQDamage(unit) > 2)
                {
                    var predQ = SpellManager.Q.GetPrediction(unit);
                    if (predQ.HitChance >= ChanceHit.GetHitChance(ChanceHit.LaneClearMinToUseQ))
                        Core.DelayAction(() => SpellManager.Q.Cast(predQ.CastPosition), delay);

                }
            }
            if (ConfigList.Farm.FarmE && SpellManager.E.IsReady() && Player.Instance.ManaPercent >= ManaManager.LaneClearE_Mana && !Player.Instance.HasBuff("RyzeQIconFullCharge"))
            {
                var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(SpellManager.E.Range));
                var monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(SpellManager.E.Range));
                if ((minions.Count() + monsters.Count()) != 0)
                {
                    var target = monsters;
                    if (monsters.Count() == 0)
                        target = minions;

                    if (target != null)
                        if (minions.Count() >= ConfigList.Farm.FarmECount || (monsters.Count() > 0 && ConfigList.Farm.FarmEIgnore))
                            SpellManager.E.Cast(target.FirstOrDefault());
                }
            }
            SpellManager.LastLaneClear = Environment.TickCount;
        }
    }
}
