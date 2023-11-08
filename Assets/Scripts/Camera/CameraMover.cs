using UnityEngine;

namespace CameraControl
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Vector2 _minMaxZoom = new Vector2(15, 25);
        [SerializeField] private float _zoomSpeed = 300f;
        private Transform _mainCameraTransform;
        private readonly float speed = 50f;
        private Vector3 CameraBorders { get; } = new Vector3(100, 0, 100);

        public float SizeWeight => 1f - (_minMaxZoom.y - UnityEngine.Camera.main.orthographicSize) /
            (_minMaxZoom.y - _minMaxZoom.x);

        private void Awake()
        {
            _mainCameraTransform = UnityEngine.Camera.main.transform;
        }

        public void MoveCamera(Vector3 p)
        {
            var newPosition = Vector3.Lerp(_mainCameraTransform.position, _mainCameraTransform.position + p * speed,
                Time.deltaTime);

            var x = newPosition.x;
            var z = newPosition.z;

            if (Mathf.Abs(x) > CameraBorders.x || Mathf.Abs(z) > CameraBorders.z) return;

            _mainCameraTransform.position = newPosition;
        }

        public void ChangeCameraZoom(float delta)
        {
            var size = UnityEngine.Camera.main.orthographicSize;
            size = Mathf.Lerp(size, size + delta * _zoomSpeed, Time.deltaTime);
            if (size < _minMaxZoom.x) size = Mathf.Lerp(size, _minMaxZoom.x, Time.deltaTime * 5f);
            if (size > _minMaxZoom.y) size = Mathf.Lerp(size, _minMaxZoom.y, Time.deltaTime * 5f);
            UnityEngine.Camera.main.orthographicSize = size;
        }
    }
}