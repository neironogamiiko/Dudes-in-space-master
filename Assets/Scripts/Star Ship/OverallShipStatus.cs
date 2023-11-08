using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using User_Interface;

namespace Star_Ship
{
    public class OverallShipStatus : MonoBehaviour
    {
        [SerializeField] private Image _overallShipStatusSlider;
        [SerializeField] private ShipComponent _ventComponent;
        [SerializeField] private ShipComponent _connectionComponent;
        [SerializeField] private ShipComponent _electroComponent;
        [SerializeField] private ShipComponent _engineComponent;
        [SerializeField] private GameOverScreen _gameOverScreen;

        public float CalculateOverall()
        {
            float overall = (_ventComponent.Health + _connectionComponent.Health + _electroComponent.Health + _engineComponent.Health) / 4f;

            return overall;
        }

        void Update()
        {
            float fill = CalculateOverall();
            _overallShipStatusSlider.fillAmount = fill * 0.01f;
            _overallShipStatusSlider.color = Color.Lerp(Color.red, Color.green, fill * 0.01f); 
            if (_ventComponent.Health == 0 || _connectionComponent.Health == 0|| _electroComponent.Health == 0 || _engineComponent.Health == 0)
            {
                _gameOverScreen.SetupDead();
            }
        }
    }
}

