using Astronaut.Interfaces;
using UnityEngine;

namespace Astronaut
{
    public class AvatarMoving : MonoBehaviour, IAvatarMoving
    {
        private Rigidbody rb;
        private readonly float speed = 100;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            var directionVector = new Vector3(h, 0, v);
            rb.velocity = directionVector * speed * 10;
        }
    }
}