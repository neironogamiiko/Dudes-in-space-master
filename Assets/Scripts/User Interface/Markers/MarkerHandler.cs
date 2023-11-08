using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace User_Interface.Markers
{
    public class MarkerHandler : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;
        private RectTransform _objectRect;
        private readonly float _scaleFactor = 0.25f;

        public Sprite MarkerIcon
        {
            set => transform.GetChild(0).GetComponent<Image>().sprite = value;
        }

        public UnityAction MarkerButton
        {
            set => transform.GetChild(0).GetComponent<Button>().onClick.AddListener(value);
        }

        private void Start()
        {
            transform.rotation = Quaternion.Euler(-46.12f, -135f, 0);
            _objectRect = GetComponent<RectTransform>();
            _camera = UnityEngine.Camera.main;
        }


        private void FixedUpdate()
        {
            _objectRect.sizeDelta = new Vector2(_camera.orthographicSize, _camera.orthographicSize) * _scaleFactor;
        }
    }
}