using System;
using Game_Events.Events;

namespace Game_Events
{
    public interface IShipEventGenerator
    {
        IShipEvent GenerateEvent();

        event Action<object, EventArgs>
            OnEventGenerated; // object - объект, который затригерил событие; TaskEventArgs - вместо кучи параметров используется класс
    }
}