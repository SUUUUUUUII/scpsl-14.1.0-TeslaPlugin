using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Loader.Features.Plugins;

namespace tesla
{
    public class TeslaScanner : Plugin
    {
        public teslaproperties.TeslaProperties teslaProperties = new teslaproperties.TeslaProperties();

        public override string Name => "TeslaPLugin";

        public override string Description => "Smart Tesla and Realistic";

        public override string Author => "IIIAuPMa";

        public override Version Version => new Version(1, 4);

        public override Version RequiredApiVersion => new Version(1, 3);

        public override void Disable()
        {
            LabApi.Events.Handlers.PlayerEvents.TriggeringTesla -= TeslaFRP;

            LabApi.Events.Handlers.ServerEvents.RoundStarted -= OffTesla;
        }

        public override void Enable()
        {
            LabApi.Events.Handlers.PlayerEvents.TriggeringTesla += TeslaFRP;

            LabApi.Events.Handlers.ServerEvents.RoundStarted += OffTesla;
        }
        public void TeslaFRP(PlayerTriggeringTeslaEventArgs ev)

        {
            if (ev.Player.IsHuman)
            {
                ev.IsAllowed = false;
            }
            if (ev.Player.IsSCP)
            {
                ev.IsAllowed = true;
            }
        }
        public void OffTesla()
        {

            teslaProperties.DisableTesla();
        }
    }
}
