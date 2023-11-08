using Astronaut.Interfaces;
using Crew.Models;
using Star_Ship;
using Star_Ship.Interfaces;
using UnityEngine;
using User_Interface;

namespace Astronaut
{
    public class Astronaut : MonoBehaviour, IAstronaut
    {
        private IPathfinder _pathfinder;
        public AstronautNavigation _navigation;

        private void Awake()
        {
            AstronautVitals = new AstronautVitals();
            _navigation = GetComponent<AstronautNavigation>();
            TryGetComponent(out _pathfinder);
            
        }

        public bool IsOccupied { get; set; } = false;

        public bool _dead { get; set; } = false;

        public CrewMemberObject PersonalInformation { get; set; }

        public Roles Role { get; set; } = Roles.ALL;

        public AstronautVitals AstronautVitals { get; private set; }

        public void Move(IShipComponent component)
        {
            if (IsOccupied == true) IsOccupied = false;
            //if (IsOccupied) return;
            _pathfinder.MoveToPosition(component.Transform.position);

        }



        void Update()
        {
 
            AstronautVitals.K2 = PersonalInformation._age / 30;

            AstronautVitals.K3 = _navigation._agent.speed / PersonalInformation._psc;

            if (AstronautVitals.Overall <= 0)
            {
                if (_dead == false) Death();

                _dead = true;
            }
        }

        public void Death()
        {
            _navigation._animator.SetBool("Move", false);

            //_navigation._agent.enabled = false;

            GetComponentInChildren<SkinnedMeshRenderer>().material = Resources.Load<Material>($"Prefabs/Materials/Ghost Material");

            GetComponentInChildren<SkinnedMeshRenderer>().castShadows = false;

            GetComponentInChildren<CapsuleCollider>().enabled = false;

            _navigation._agent.areaMask = 4;

            _navigation._agent.speed = 3;

            //gameObject.SetActive(false);

            //GetComponentInParent<Crew.Models.Crew>()._gameOverScreen.SetupDead();
        }

        void OnMouseOver()
        {
            Debug.Log("govno");
        }
    }



}