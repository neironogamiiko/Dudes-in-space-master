using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace User_Interface.Tasks
{
    public class MinigameMain : MonoBehaviour
    {
        public bool solved;

        public Slider coundownSlider;

        public void CloseMenu()
        {
            gameObject.SetActive(false);
        }
    }
}

