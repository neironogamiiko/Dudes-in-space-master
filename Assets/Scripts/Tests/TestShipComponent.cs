using Star_Ship.EventArgs;
using Star_Ship.Interfaces;
using UnityEngine;

namespace Tests
{
    public class TestShipComponent : MonoBehaviour
    {
        private IShipComponent _shipComponent;

        private void Awake()
        {
            if (TryGetComponent(out _shipComponent)) RunTests();
        }

        private void CheckForBreakCycle()
        {
        }

        private void OnShipBroke(object s, ShipComponentArgs args)
        {
            Debug.Log("Ship is broken!");
        }

        private void RunTests()
        {
            CheckForBreakCycle();
        }
    }
}