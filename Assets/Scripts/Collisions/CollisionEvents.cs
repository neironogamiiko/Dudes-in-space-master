using System;
using UnityEngine;

namespace Collisions
{
    public class CollisionEvents : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            CallStartCollision(collision.gameObject);
        }

        private void OnCollisionStay (Collision collision)
        {
            CallStartTrigger(collision.gameObject);

        }

        private void OnCollisionExit(Collision collision)
        {
            CallEndCollision(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            CallStartTrigger(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            CallEndTrigger(other.gameObject);
        }

        public event Action<GameObject> OnStartCollision;
        public event Action<GameObject> OnStartTrigger;
        public event Action<GameObject> OnExitCollision;
        public event Action<GameObject> OnExitTrigger;

        private void CallStartCollision(GameObject obj)
        {
            OnStartCollision?.Invoke(obj);
        }

        private void CallStartTrigger(GameObject obj)
        {
            OnStartTrigger?.Invoke(obj);
        }

        private void CallEndCollision(GameObject obj)
        {
            OnExitCollision?.Invoke(obj);
        }

        private void CallEndTrigger(GameObject obj)
        {
            OnExitTrigger?.Invoke(obj);
        }
    }
}