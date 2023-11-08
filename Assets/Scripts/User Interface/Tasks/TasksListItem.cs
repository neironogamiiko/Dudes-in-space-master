using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace User_Interface.Tasks
{
    public class TasksListItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public void SetImage(Sprite image)
        {
            if (_image != null)
                _image.sprite = image;
        }

        public void SetText(string text)
        {
            if (text != null)
                _text.text = text;
        }
    }
}