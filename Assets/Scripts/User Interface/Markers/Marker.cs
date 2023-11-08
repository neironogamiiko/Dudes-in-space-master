using System;
using Star_Ship.EventArgs;
using Star_Ship.Interfaces;

namespace User_Interface.Markers
{
    public class Marker
    {
        private bool _isConnectedToHandler;

        public Marker(MarkerHandler handler, IShipComponentInformation module)
        {
            Handler = handler;
            Module = module;
        }

        public IShipComponentInformation Module { get; }
        public MarkerHandler Handler { get; }
        public event Action<object, RoomMarkerEventArgs> OnMarkerClick;

        private void OnMarkerSelected()
        {
            OnMarkerClick?.Invoke(this, new RoomMarkerEventArgs(Module as IShipComponent));
        }

        public void ConnectModuleWithHandler()
        {
            if (_isConnectedToHandler)
                return;

            Handler.MarkerIcon = Module.ComponentInformation._sprite;
            Handler.MarkerButton = OnMarkerSelected;

            _isConnectedToHandler = true;
        }
    }
}