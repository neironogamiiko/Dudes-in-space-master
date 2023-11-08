using UnityEngine;

namespace User_Interface.Tasks
{
    public class TaskMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public void Setup()
        {
            if (gameObject.activeInHierarchy == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
    }
}