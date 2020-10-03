using Exiled.API.Features;
using HarmonyLib;
using System;
using Handlers = Exiled.Events.Handlers;

namespace EscapeReloaded
{
    public class Plugin : Plugin<Config>
    {
        public EventHandlers EventHandlers;

        public static Plugin Instance { get; private set; }
        public static Harmony Harmony { get; private set; }

        public override string Author { get; } = "gamehunt | Arith";
        public override string Name { get; } = "EscapeReloaded";
        public override string Prefix { get; } = "EscapeReloaded";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 7);

        public override void OnEnabled()
        {
            try
            {
                Instance = this;

                Harmony = new Harmony("escapereloaded.instance");

                EventHandlers = new EventHandlers();

                Handlers.Server.RoundStarted += EventHandlers.OnRoundStart;
                Handlers.Server.RoundEnded += EventHandlers.OnRoundEnd;

                Log.Info($"EscapeReloaded plugin loaded. @gamehunt @Arith");
            }
            catch (Exception e)
            {
                Log.Error($"There was an error loading the plugin: {e}");
            }
        }

        public override void OnDisabled()
        {
            Handlers.Server.RoundStarted -= EventHandlers.OnRoundStart;
            Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnd;

            EventHandlers = null;
        }

        public override void OnReloaded()
        {
        }
    }
}