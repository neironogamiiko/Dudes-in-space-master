using UnityEngine;

namespace User_Interface
{
    public class Settings : MonoBehaviour
    {
        public void Setup()
        {
            if (gameObject.activeInHierarchy == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }

        public void Resume()
        {
            gameObject.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}