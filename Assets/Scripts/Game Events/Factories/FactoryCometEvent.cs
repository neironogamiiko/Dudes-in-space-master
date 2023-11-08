using Game_Events.Events;

namespace Game_Events.Factories
{
    public class FactoryCometEvent : IFactoryEvents
    {
        public IShipEvent Create()
        {
            IShipEvent Comet = new CometEvent();
            return Comet;
        }
    }
}