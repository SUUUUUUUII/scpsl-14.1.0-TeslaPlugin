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
                    if (Cassie.IsSpeaking)
                    {

                        response = "Wait until CASSIE Speak";

                        return false;

                    }
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

                        Timing.CallDelayed(8, () => properties.EnableTesla());

                        if (tesla.enabled == true)

                        {

                            response = "Tesla Gate's already engage!";

                            return false;

                        }
                        Cassie.Message("pitch_00.97 . . . Attention . All pitch_01.03 Tesla pitch_01.00 gate1 are now Enabled", false, true, true, "Внимание все ворота тесла включены!");

                        break;
                    }
                    if (arguments.At(0) == "off" && arguments.Count > 0)
                    {
                        response = "Tesla Gates disengaging";

                        Timing.CallDelayed(8, () => properties.DisableTesla());

                        if (tesla.enabled == false)
                        {

                            response = "Tesla Gate's already disengage!";

                            return false;


                        }
                        Cassie.Message("pitch_00.97 . . . Attention . All pitch_01.03 Tesla pitch_01.00 gate1 are now Disabled", false, true, true, "Внимание все ворота тесла отключены!");

                        break;
                    }


                }


            }

            response = null;

            return false;
        }



    }


}
