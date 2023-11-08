using UnityEngine;
using User_Interface.Tasks;

namespace User_Interface
{
    public class Dead : MonoBehaviour
    {
        public GameOverScreen gO;
        public GameOverScreen gW;
        public Settings set;
        public TaskMenu tasks;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) gO.SetupDead();
            if (Input.GetKeyDown(KeyCode.L)) gW.SetupWin();
            if (Input.GetKeyDown(KeyCode.Escape)) set.Setup();
            if (Input.GetKeyDown(KeyCode.J)) tasks.Setup();
        }
    }
}