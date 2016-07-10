using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;
using SharpDX;
using System;
using System.Linq;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using ReKatarina.Utility;

namespace ReKatarina
{
    class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Katarina")
            {
                return;
            }

            Config.Initialize();
            Drawing.OnDraw += OnDraw;
            Game.OnTick += OnTick;
            Game.OnUpdate += OnTick;
            Drawing.OnEndScene += OnEndScene;

            Chat.Print("ReKatarina has been loaded. GL HF;");
        }

        private static void OnEndScene(EventArgs args)
        {
            if (Player.Instance.IsDead || !ConfigList.Drawing.DrawDI)
                return;

            Indicator.Execute();
        }

        private static void OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead || Player.Instance.IsRecalling()) 
                return;

            PermaActive.Execute();
            var flags = Orbwalker.ActiveModesFlags;
            if (flags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Harass.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                LastHit.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Farm.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                Farm.Execute();
            }
            if (flags.HasFlag(Orbwalker.ActiveModes.Flee))
            {
                Flee.Execute();
            }
        }
        
        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead)
                return;

            foreach (var spell in SpellManager.AllSpells)
            {
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        if (!ConfigList.Drawing.DrawQ)
                            continue;
                        break;
                    case SpellSlot.W:
                        if (!ConfigList.Drawing.DrawW)
                            continue;
                        break;
                    case SpellSlot.E:
                        if (!ConfigList.Drawing.DrawE)
                            continue;
                        break;
                    case SpellSlot.R:
                        if (!ConfigList.Drawing.DrawR)
                            continue;
                        break;
                }
                Circle.Draw(spell.GetColor(), spell.Range, Player.Instance);
            }
        }
    }
}
