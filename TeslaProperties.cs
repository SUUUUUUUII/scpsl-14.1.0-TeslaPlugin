using LabApi.Features.Wrappers;

namespace teslaproperties
{
    public class TeslaProperties
    {
        public void DisableTesla()
        {
            foreach (TeslaGate tesla in TeslaGate.AllGates)
            {
                tesla.enabled = false;
            }
        }
        public void EnableTesla()
        {
            foreach (TeslaGate tesla in TeslaGate.AllGates)
            {
            tesla.enabled = true;
            }
        }
    }
}
