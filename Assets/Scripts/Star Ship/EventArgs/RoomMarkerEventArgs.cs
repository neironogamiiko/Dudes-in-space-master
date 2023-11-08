using Star_Ship.Interfaces;

namespace Star_Ship.EventArgs
{
    public class RoomMarkerEventArgs : System.EventArgs
    {
        public RoomMarkerEventArgs(IShipComponent shipComponent)
        {
            ResponsibleComponent = shipComponent;
        }

        public IShipComponent ResponsibleComponent { get; }
    }
}