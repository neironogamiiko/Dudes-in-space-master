using Star_Ship;
using UnityEngine;

namespace Tests
{
    public class PathfinderAstronautTest : MonoBehaviour
    {
        [SerializeField] private Astronaut.Astronaut _astronaut;
        [SerializeField] private ShipComponent _shipComponent;

        private void Start()
        {
            StartTests();
        }

        private void Update()
        {
            StartTests();
        }

        private void StartTests()
        {
            _astronaut.Move(_shipComponent);
        }
    }
}