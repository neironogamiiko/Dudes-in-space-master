using System;
using Game_Events.Events;
using Game_Events.Factories;
using Random = UnityEngine.Random;

namespace Game_Events
{
    public class ShipEventGenerator : IShipEventGenerator
    {
        private readonly IFactoryEvents[] eventList =
            { new FactoryQuarantineEvent(), new FactoryCometEvent(), new FactorySolarWindEvent() };

        public event Action<object, EventArgs> OnEventGenerated;

        public IShipEvent GenerateEvent()
        {
            var index = Random.Range(0, eventList.Length);
            return eventList[index].Create();
        }
    }
}