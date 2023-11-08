using Game_Events.Events;

namespace Game_Events.Factories
{
    public class FactorySolarWindEvent : IFactoryEvents
    {
        public IShipEvent Create()
        {
            IShipEvent SolarWind = new SolarWindEvent();
            return SolarWind;
        }
    }
}