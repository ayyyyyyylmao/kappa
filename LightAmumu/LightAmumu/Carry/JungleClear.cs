using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace LightAmumu.Carry
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            int monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(W.Range * 2)).Count();
            if (monsters != 0)
            {
                if (MenuList.Farm.WithQ && Player.Instance.ManaPercent >= MenuList.Mana.minJngQ)
                {
                    var targetmonster = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(Q.Range));
                    Q.Cast(targetmonster.FirstOrDefault());
                }

                if (Damage.WStatus() == true && Player.Instance.ManaPercent < MenuList.Mana.minJngW)
                    Damage.WDisable();
                else
                    if (MenuList.Farm.WithW && Player.Instance.ManaPercent >= MenuList.Mana.minJngW)
                        Damage.WEnable();

                if (MenuList.Farm.WithE && Player.Instance.ManaPercent >= MenuList.Mana.minJngE)
                {
                    var targetmonster = EntityManager.MinionsAndMonsters.Monsters;
                    foreach (var select in targetmonster)
                    {
                        if (select.IsValidTarget(E.Range))
                            E.Cast(); return;
                    }
                }
            }
        }
    }
}