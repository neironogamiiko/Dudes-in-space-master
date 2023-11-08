using UnityEngine;

namespace CameraControl
{
    public class PlayerCameraInput : MonoBehaviour
    {
        [SerializeField] private CameraMover _cameraMover;
        private float _scrollImpulse;

        private void Update()
        {
            _cameraMover.MoveCamera(GetBaseInput());
            GetScrollInput();
            _cameraMover.ChangeCameraZoom(_scrollImpulse);
        }

        private void GetScrollInput()
        {
            var axisScroll = Input.GetAxis("MouseScrollWheel");
            _scrollImpulse -= axisScroll;
            _scrollImpulse = Mathf.Lerp(_scrollImpulse, 0f, Time.deltaTime * 10f);
        }

        private Vector3 GetBaseInput()
        {
            var p_Velocity = Vector3.zero;

            // TODO Smooth scroll to zoom in/out
            // TODO crossplatform controls

            p_Velocity += new Vector3(1, 0, 1).normalized * Input.GetAxis("Vertical");
            p_Velocity += new Vector3(1, 0, -1).normalized * Input.GetAxis("Horizontal");

            return p_Velocity;
        }
    }
}