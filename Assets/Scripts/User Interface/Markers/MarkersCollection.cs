using System;
using System.Collections.Generic;
using Star_Ship;
using Star_Ship.EventArgs;
using Star_Ship.Interfaces;
using UnityEngine;

namespace User_Interface.Markers
{
    public class MarkersCollection : MonoBehaviour
    {
        [SerializeField] private SpaceShip _ship;
        [SerializeField] private GameObject _markerHandlerPrefab;
        private List<Marker> _markers;

        private void Awake()
        {
            _markers = new List<Marker>();
            _ship.OnShipComponentLoaded += _ship_OnShipComponentLoaded;
            Debug.Log("Markers loaded!");
        }

        public event Action<object, RoomMarkerEventArgs> OnMarkerSelected;

        private void _ship_OnShipComponentLoaded(object sender, ShipComponentLoadedArgs args)
        {
            foreach (var comp in args.ListShipComponents)
            {
                var handler =
                    Instantiate(_markerHandlerPrefab, comp.Transform.position + Vector3.up * 5, Quaternion.identity,
                        transform).GetComponent<MarkerHandler>();
                comp.SetSlider(handler.gameObject);
                var marker = new Marker(handler, comp as IShipComponentInformation);
                marker.ConnectModuleWithHandler();
                marker.OnMarkerClick += AnyMarkerWasSelected;
                _markers.Add(marker);
            }
        }

        private void AnyMarkerWasSelected(object sender, RoomMarkerEventArgs args)
        {
            OnMarkerSelected?.Invoke(sender, args);
        }

        // TODO create unload
    }
}