using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace LightAmumu.Carry
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            int minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(minion => minion.IsValidTarget(W.Range)).Count();
            if (minions != 0)
            {
                if (Damage.WStatus() == true && Player.Instance.ManaPercent < MenuList.Mana.minLnW)
                    Damage.WDisable();
                else
                    if (MenuList.Farm.WithW && Player.Instance.ManaPercent >= MenuList.Mana.minLnW)
                        Damage.WEnable();

                if (MenuList.Farm.WithE && Player.Instance.ManaPercent >= MenuList.Mana.minLnE)
                {
                    var minion = EntityManager.MinionsAndMonsters.EnemyMinions;
                    foreach (var select in minion)
                    {
                        if (select.IsValidTarget(E.Range))
                            E.Cast();
                    }
                }
            }
        }
    }
}