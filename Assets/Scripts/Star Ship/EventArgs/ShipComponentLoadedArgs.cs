using System.Collections.Generic;
using Star_Ship.Interfaces;

namespace Star_Ship.EventArgs
{
    public class ShipComponentLoadedArgs : System.EventArgs
    {
        public ShipComponentLoadedArgs(List<IShipComponent> components)
        {
            ListShipComponents = components;
        }

        public IEnumerable<IShipComponent> ListShipComponents { get; }
    }
}