using UnityEngine;

namespace CameraControl
{
    public class CameraController : MonoBehaviour
    {
        public Vector3 cameraPos;
        public Vector3 offset;

        private int counterMouseWheel = 50;

        private Vector3 objPos; //positin of object 
        private readonly float smoothing = 1;

        private readonly float smoothSpeed = 3;

        private Vector3 startPosition; // start position of camera


        private void Start()
        {
            cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position; //getting start coordinate
            startPosition = cameraPos;
            Debug.Log("Camera pos" + startPosition);
        }

        private void Update()
        {
            cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;

            TransformCameraPosition();

            objPos = GameObject.FindGameObjectWithTag("Obj").transform.position;
        }

        private void TransformCameraPosition()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && counterMouseWheel > 0) //
            {
                transform.position = Vector3.Lerp(transform.position, objPos, smoothing * smoothSpeed * Time.deltaTime);
                counterMouseWheel--;
            }


            if (Input.GetAxis("Mouse ScrollWheel") < 0 && counterMouseWheel < 50)
            {
                transform.position = Vector3.Lerp(transform.position, startPosition,
                    smoothing * smoothSpeed * Time.deltaTime);
                counterMouseWheel++;
                Debug.Log(counterMouseWheel);
            }
        }
    }
}