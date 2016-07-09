using System;
using EloBuddy;
using EloBuddy.SDK;

namespace ReGaren.Utility
{
    public static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Mixed, Player.Instance.Position);
            if (target == null)
                return;

            foreach (var spell in SpellManager.AllSpells)
            {
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                    {
                        if (!ConfigList.Combo.ComboQ)
                            continue;
                        
                        if (SpellManager.Q.IsReady())
                        {
                            SpellManager.Q.Cast();
                            Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                        }
                        break;
                    }
                    case SpellSlot.W:
                    {
                        if (!ConfigList.Combo.ComboW)
                            continue;

                        if (SpellManager.W.IsReady())
                            SpellManager.W.Cast();
                        break;
                    }
                    case SpellSlot.E:
                    {
                        if (!ConfigList.Combo.ComboE)
                            continue;

                        if (SpellManager.E.IsReady())
                            SpellManager.E.Cast();
                        break;
                    }
                    case SpellSlot.R:
                    {
                        if (!ConfigList.Combo.ComboR)
                            continue;

                        if (Damage.GetRDamage(target) - 5 >= target.Health)
                        {
                            SpellManager.R.Cast(target);
                        }
                            
                        break;
                    }
                }
            }
        }
    }
}
