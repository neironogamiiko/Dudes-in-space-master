using Astronaut.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Astronaut
{
    public class AstronautNavigation : MonoBehaviour, IPathfinder
    {
        public NavMeshAgent _agent;
        public Animator _animator;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _animator = GetComponentInChildren<Animator>();
        }

        public void MoveToPosition(Vector3 position)
        {
            _agent.SetDestination(position);

            _animator.SetBool("Move", true);

            _agent.speed = 5;
        }

        void Update()
        {
            if (GetComponent<Astronaut>().IsOccupied == true)
            {
                _animator.SetBool("Move", false);

                _agent.speed = 0;
            }

        }
    }


    
}