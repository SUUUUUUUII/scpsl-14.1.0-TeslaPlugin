using CommandSystem;
using LabApi.Features.Wrappers;
using MEC;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using teslaproperties;
using UnityEngine;
using ICommand = CommandSystem.ICommand;

namespace TeslaCommand
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TeslaArgument : ICommand
    {
        public teslaproperties.TeslaProperties tesla = new TeslaProperties();

        public teslaproperties.TeslaProperties properties = new teslaproperties.TeslaProperties();
        public string Command => "tesla";
        public string[] Aliases => new[] { "tsl", "" };
        public string Description => "Controll with All Tesla Gates <color=yellow> {on} {off}";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender.CheckPermission(PlayerPermissions.PlayersManagement))
            {
                foreach (TeslaGate tesla in TeslaGate.AllGates)
                {
                    if (arguments.At(0) == "on" && arguments.Count > 1)
                    {
                        response = "Please put correct value";

                        return false;
                    }
                    if (arguments.At(0) == "off" && arguments.Count > 1)
                    {
                        response = "Please put correct value";

                        return false;
                    }
                    if (arguments.Count == 0)
                    {
                        response = "Please put correct value";

                        return false;
                    }
                    if (arguments.At(0) == "on" && arguments.Count > 0)
                    {
                        response = "Tesla Gates engaging";

                        Timing.CallDelayed(1, () => properties.EnableTesla());

                        if (tesla.enabled == true)
                        {
                            response = "Tesla Gate's already engage!";

                            return false;
                        }                       
                        break;
                    }
                    if (arguments.At(0) == "off" && arguments.Count > 0)
                    {
                        response = "Tesla Gates disengaging";

                        Timing.CallDelayed(1, () => properties.DisableTesla());

                        if (tesla.enabled == false)
                        {
                            response = "Tesla Gate's already disengage!";

                            return false;
                        }                        
                        break;
                    }
                }
            }

            response = null;

            return false;
        }
    }
}

