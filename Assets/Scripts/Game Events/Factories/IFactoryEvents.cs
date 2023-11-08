using Game_Events.Events;

namespace Game_Events.Factories
{
    public interface IFactoryEvents
    {
        IShipEvent Create();
    }
}