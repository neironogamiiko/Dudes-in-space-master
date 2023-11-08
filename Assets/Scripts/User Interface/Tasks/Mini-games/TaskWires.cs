using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace User_Interface.Tasks
{
    public class TaskWires : MonoBehaviour
    {
        [SerializeField] private GameObject _wirePrefab;
        [SerializeField] private Transform _wiresPanel;
        [SerializeField] private Transform survBG;
        public Slider solveTimer;
        [SerializeField] private Text _clueTxt;
        static private int wiresCount = 3;
        //[SerializeField] private List<GameObject> wiresList = new List<GameObject>();
        public List<string> solution = new List<string>(wiresCount);
        public List<string> suggestion = new List<string>(wiresCount);
        public List<string> survey = new List<string>(wiresCount);
        public List<string> solutionExp = new List<string>(wiresCount);
        public int pluggingCount;
        public List<string> order = new List<string>(wiresCount);
        [SerializeField] private List<GameObject> questionsList = new List<GameObject>(wiresCount);
        [SerializeField] private int stage;
        public AudioSource cutTheAudio;
        public AudioSource wireAudio;
        public AudioSource successAudio;
        public AudioSource failureAudio;
        [SerializeField] private List<AudioSource> audioList = new List<AudioSource>();
        [SerializeField] private List<int> nums = new List<int>();
        bool red;
        bool blue;
        bool white;
        public Image lightImg;
        private bool light;
        //public Slider coundownSlider { get; set; }
        //public bool solved { get; set; }
        [SerializeField] private MinigameMain _minigameMain;

        void Start()
        {
            SetupWires();

            _minigameMain.solved = false;
        }

        void SetupWires()
        {
            //wiresCount = Random.Range(3, 5);

            //StartCoroutine("GenerateTask");

            int m = Random.Range(0, 2);

            if (m == 0)
            {
                lightImg.color = new Color32(255, 0, 0, 255);

                light = true;
            }



            while (nums.Count < wiresCount)
            {
                int n = Random.Range(0, wiresCount);

                if (!nums.Contains(n)) nums.Add(n);
            }


            for (int i = 0; i < wiresCount; i++)
            {
                int x = nums[i];

                //var rnd = new System.Random();

                //int x = rnd.Next(nums.Count);



                //int x = 0;

                //System.Random rnd = new System.Random();


                ///x = rnd.Next(0, nums.Count);

                //nums.Remove(x);

                GameObject clone;

                clone = Instantiate(_wirePrefab, _wiresPanel.position + new Vector3(0, i * -50f, 0), _wiresPanel.rotation, _wiresPanel);

                //clone = Instantiate(_wirePrefab, _wiresPanel);

                if (x == 0)
                {
                    if (red == false)
                    {
                        clone.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);

                        clone.name = "Red";

                        red = true;

                        order[i] = clone.name;
                    }




                }
                else if (x == 1)
                {


                    if (blue == false)
                    {
                        clone.transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 255, 255);

                        clone.name = "Blue";

                        blue = true;

                        order[i] = clone.name;
                    }



                }
                else if (x == 2)
                {



                    if (white == false)
                    {
                        clone.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                        clone.name = "White";

                        white = true;

                        order[i] = clone.name;
                    }

                }

            }


            solution = Compare(order, light);

            
        }

        public void Quiz(int answer)
        {
            bool light1 = false;
            if (answer == 0) survey[stage] = "Red";
            else if (answer == 1) survey[stage] = "Blue";
            else if (answer == 2) survey[stage] = "White";
            else if (answer == 3) light1 = true;
            else if (answer == 4) light1 = false;


            stage++;
            survBG.GetChild(stage).gameObject.SetActive(true);
            survBG.GetChild(stage - 1).gameObject.SetActive(false);
            solutionExp = Compare(survey, light1);

            if (stage > 3) _clueTxt.text = "Recommended sequence: " + solutionExp[0] + ", " + solutionExp[1] + ", " + solutionExp[2];
        }

        List<string> Compare(List<string> list1, bool lightning)
        {
            List<string> list2 = new List<string>(wiresCount);

            if (order[0] == "Red" && order[1] == "Blue" && order[2] == "White")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "White", "Red", "Blue" };
                else list2 = new List<string>(wiresCount) { "Red", "Blue", "White" };
            }
            else if (order[0] == "Red" && order[1] == "White" && order[2] == "Blue")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "Red", "Blue", "White" };
                else list2 = new List<string>(wiresCount) { "Blue", "White", "Red" };
            }
            else if (order[0] == "Blue" && order[1] == "Red" && order[2] == "White")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "Blue", "White", "Red" };
                else list2 = new List<string>(wiresCount) { "White", "Red", "Blue" };
            }
            else if (order[0] == "Blue" && order[1] == "White" && order[2] == "Red")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "White", "Red", "Blue" };
                else list2 = new List<string>(wiresCount) { "Blue", "White", "Red" };

            }
            else if (order[0] == "White" && order[1] == "Blue" && order[2] == "Red")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "Blue", "White", "Red" };
                else list2 = new List<string>(wiresCount) { "White", "Blue", "Red" };

            }
            else if (order[0] == "White" && order[1] == "Red" && order[2] == "Blue")
            {
                if (lightning == true) list2 = new List<string>(wiresCount) { "White", "Blue", "Red" };
                else list2 = new List<string>(wiresCount) { "Red", "Blue", "White" };
            }

            return list2;
        }

        void Update()
        {
            //if (pluggingCount >= 3) Solve();      
        }

        public void Solve()
        {
            if (pluggingCount >= 3)
            {
                int m = 0;


                for (int i = 0; i < 3; i++)
                {
                    if (suggestion[i] == solution[i])
                    {
                        m++;
                    }

                    survBG.GetChild(i).gameObject.SetActive(false);
                }

                survBG.GetChild(4).gameObject.SetActive(true);

                if (m == 3)
                {

                    survBG.GetChild(4).gameObject.GetComponent<Text>().text = "Component repair completed successfully!";

                    _minigameMain.solved = true;

                    //Destroy(this.gameObject);
                }
                else
                {
                    if (_wiresPanel.childCount > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Destroy(_wiresPanel.GetChild(i).gameObject);
                        }
                    }
                    SetupWires();

                    _minigameMain.solved = false;

                    survBG.GetChild(4).gameObject.GetComponent<Text>().text = "Ooops! Something went wrong... Try again.";
                }
            }
        }

        
    }

}
