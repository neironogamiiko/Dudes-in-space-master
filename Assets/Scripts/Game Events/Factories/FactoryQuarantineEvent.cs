using Game_Events.Events;

namespace Game_Events.Factories
{
    public class FactoryQuarantineEvent : IFactoryEvents
    {
        public IShipEvent Create()
        {
            IShipEvent Quarantine = new QuarantineEvent();
            return Quarantine;
        }
    }
}