using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using System;
using System.Linq;

namespace ReKatarina.Utility
{
    public static class Flee
    {
        public static bool IsWard(Vector3 pos)
        {
            return ObjectManager.Get<Obj_AI_Base>().Any(a => a.IsAlly && a.Distance(pos) <= ConfigList.Flee.JumpCursorRange);
        }
        public static bool IsAlly(Vector3 pos)
        {
            return EntityManager.Heroes.Allies.Any(a => !a.IsMe && a.Distance(pos) <= ConfigList.Flee.JumpCursorRange);
        }
        public static bool IsAllyMinion(Vector3 pos)
        {
            return EntityManager.MinionsAndMonsters.AlliedMinions.Any(a => a.Distance(pos) <= ConfigList.Flee.JumpCursorRange);
        }
        public static bool IsEnemyMinion(Vector3 pos)
        {
            return EntityManager.MinionsAndMonsters.EnemyMinions.Any(a => a.Distance(pos) <= ConfigList.Flee.JumpCursorRange);
        }
        public static bool IsMonster(Vector3 pos)
        {
            return EntityManager.MinionsAndMonsters.Monsters.Any(a => a.Distance(pos) <= ConfigList.Flee.JumpCursorRange);
        }

        public static void Execute()
        {
            if (!SpellManager.E.IsReady() || Damage.HasRBuff())
                return;

            var mouse = Game.CursorPos;
            if (ConfigList.Flee.EnableWards)
            {
                if (IsWard(mouse))
                {
                    var target = ObjectManager.Get<Obj_AI_Base>().
                        Where(a => a.IsAlly && a.IsInRange(a, SpellManager.E.Range) && a.Distance(mouse) <= ConfigList.Flee.JumpCursorRange);
                    SpellManager.E.Cast(target.FirstOrDefault());
                    SpellManager.LastJumpCast = Environment.TickCount;
                    return;
                }
            }
            if (ConfigList.Flee.JumpToAlly)
            {
                if (IsAlly(mouse))
                {
                    var target = EntityManager.Heroes.Allies.
                        Where(a => !a.IsMe && a.IsInRange(a, SpellManager.E.Range) && a.Distance(mouse) <= ConfigList.Flee.JumpCursorRange);
                    SpellManager.E.Cast(target.FirstOrDefault());
                    return;
                }
            }
            if (ConfigList.Flee.JumpToAllyMinion)
            {
                if (IsAllyMinion(mouse))
                {
                    var target = EntityManager.MinionsAndMonsters.AlliedMinions.
                        Where(a => a.IsInRange(a, SpellManager.E.Range) && a.Distance(mouse) <= ConfigList.Flee.JumpCursorRange);
                    SpellManager.E.Cast(target.FirstOrDefault());
                    return;
                }
            }
            if (ConfigList.Flee.JumpToEnemyMinion)
            {
                if (IsEnemyMinion(mouse))
                {
                    var target = EntityManager.MinionsAndMonsters.EnemyMinions.
                        Where(a => a.IsInRange(a, SpellManager.E.Range) && a.Distance(mouse) <= ConfigList.Flee.JumpCursorRange);
                    SpellManager.E.Cast(target.FirstOrDefault());
                    return;
                }
            }
            if (ConfigList.Flee.JumpToMonster && (EloBuddy.Player.Instance.HealthPercent >= (float)ConfigList.Flee.JumpToMonsterHP))
            {
                if (IsMonster(mouse)) 
                {
                    var target = EntityManager.MinionsAndMonsters.Monsters.
                        Where(a => a.IsInRange(a, SpellManager.E.Range) && a.Distance(mouse) <= ConfigList.Flee.JumpCursorRange);
                    SpellManager.E.Cast(target.FirstOrDefault());
                    return;
                }
            }
        }
    }
}
