using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User_Interface
{
    public class GameOverScreen : MonoBehaviour
    {
        public static GameOverScreen instance;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        private int _counter;

        private void Awake()
        {
            instance = this;
            if (PlayerPrefs.HasKey("restartCounter")) _counter = PlayerPrefs.GetInt("restartCounter");
        }

        public void SetupDead()
        {
            gameObject.SetActive(true);
            _gameOverText.SetText($"Expedition failed(");
        }

        public void SetupWin()
        {
            gameObject.SetActive(true);
            _gameOverText.SetText("Team successfully reached Mars!");
        }

        public void RestartButton()
        {
            RestartCounter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void RestartCounter()
        {
            _counter++;
            //_counter = 0;
            PlayerPrefs.SetInt("restartCounter", _counter);
        }
    }
}