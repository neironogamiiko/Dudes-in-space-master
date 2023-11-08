using System;
using System.Collections;
using Timer.EventArgs;
using Timer.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using User_Interface;

namespace Timer
{
    public class Timer : MonoBehaviour, IShipDayTimer
    {
        [SerializeField] private int _dayMinutes = 3;
        public int daysToWin = 7;
        [SerializeField] private Slider _sliderTimer;
        [SerializeField] private AudioSource _newDayAudio;
        [SerializeField] private AudioClip _newDaySoundEffect;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private Text _dayNum;

        private int _daysCounter;
        private int _time;

        private void Start()
        {
            RestartTimer();
            _sliderTimer.value = 1;
            StartNewDay();
        }

        private void FixedUpdate()
        {
            UpdateSliderVisuals();
        }

        public event Action<object, ShipDayArgs> OnNewDayStarted;
        public event Action<object, ShipDayArgs> OnDayEnded;

        private void RestartTimer()
        {
            _time = _dayMinutes * 60;
        }
        public void PlayAudio()
        {
            _newDayAudio.PlayOneShot(_newDaySoundEffect);
        }

        private void StartNewDay()
        {
            if (_daysCounter >= daysToWin) _gameOverScreen.SetupWin();
            RestartTimer();
            if (_daysCounter > 0) PlayAudio();
            _daysCounter++;
            _dayNum.text = "Day: " + _daysCounter + "/" + daysToWin;
            StartCoroutine(CountTimer());
            OnNewDayStarted?.Invoke(this, new ShipDayArgs(false, _daysCounter));
        }

        private void UpdateSliderVisuals()
        {
            _sliderTimer.value = Mathf.Lerp(_sliderTimer.value, _time / (_dayMinutes * 60f), Time.fixedDeltaTime);
        }

        private IEnumerator CountTimer()
        {
            while (_time > 0)
            {
                _time--;
                yield return new WaitForSeconds(1);
            }

            OnDayEnded?.Invoke(this, new ShipDayArgs(false, _daysCounter));
            yield return new WaitForSeconds(5);
            StartNewDay();
        }
    }
}