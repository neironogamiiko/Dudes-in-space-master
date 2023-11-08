using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace User_Interface.Tasks
{
    public interface IMinigame
    {
        public void CloseMenu();

        public bool solved { get; set; }

        public Slider coundownSlider { get; set; }

    }
}


