using UnityEngine;

namespace Collisions
{
    public class DoorActivator : MonoBehaviour
    {
        [SerializeField] private CollisionEvents _events;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _events.OnStartTrigger += OnCallTriggerEnter;
            _events.OnExitTrigger += OnCallTriggerExit;
        }

        private void CloseDoors()
        {
            _animator.SetBool("isOpen", false);
        }

        private void OpenDoors()
        {
            _animator.SetBool("isOpen", true);
        }

        private void OnCallTriggerEnter(GameObject obj)
        {
            OpenDoors();
        }

        private void OnCallTriggerExit(GameObject obj)
        {
            CloseDoors();
        }
    }
}