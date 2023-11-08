using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace User_Interface.Tasks
{
    public class TaskVent : MonoBehaviour
    {
        [SerializeField] private Sprite _switchSpryteL;
        [SerializeField] private Sprite _switchSpryteR;
        [SerializeField] private Transform _arrowSprite;
        [SerializeField] private Button _switch1;
        [SerializeField] private Slider _switch2;
        [SerializeField] private Button _switch3;
        [SerializeField] static private int _swithesAmount = 4;
        [SerializeField] static private int _stagesAmount = 4;
        [SerializeField] private int _meterCurrValue;
        [SerializeField] private List<int> _meterValues = new List<int> { 0, 25, 50, 75, 100 };
        [SerializeField] private List<GameObject> _listOfSwitches = new List<GameObject>(_swithesAmount);
        [SerializeField] private List<int> _keepAnswer = new List<int>(_stagesAmount - 1);
        [SerializeField] private int stage;
        [SerializeField] private Sprite switch1L;
        [SerializeField] private Sprite switch1R;
        [SerializeField] private Sprite switch2L;
        [SerializeField] private Sprite switch2R;
        [SerializeField] private Transform _attemptsCounter;
        [SerializeField] private int _maxAttempts = 3;
        [SerializeField] private Transform _survey;
        [SerializeField] private Transform _answerField;
        [SerializeField] private Text _clueTxt;
        [SerializeField] private int _correctSwitch;
        //public Slider coundownSlider { get; set; }
        [SerializeField] private MinigameMain _minigameMain;

        void Start()
        {
            for (int i = 0; i < _swithesAmount; i++)
            {
                _listOfSwitches.Add(transform.GetChild(i).gameObject);
            }

            SetMeter();

            _minigameMain.solved = false;
        }


        void SetMeter()
        {
            int rnd = Random.Range(0, _meterValues.Count);

            _meterCurrValue = _meterValues[rnd];

            //_arrowSprite.Rotate(new Vector3(0, 0, 3.6f * _meterCurrValue));
            //if (Mathf.Round(_arrowSprite.eulerAngles.z) == 180)  _arrowSprite.Rotate(new Vector3(0, 0, -180)); 

            switch (_meterCurrValue)
            {
                case 0:
                    {
                        _arrowSprite.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
                    }
                    break;

                case 25:
                    {
                        _arrowSprite.rotation = new Quaternion(0, 0, 0.382683426f, 0.923879564f);
                    }
                    break;

                case 50:
                    {
                        _arrowSprite.rotation = new Quaternion(0, 0, 0, 1f);
                    }
                    break;

                case 75:
                    {
                        _arrowSprite.rotation = new Quaternion(0, 0, -0.382683426f, 0.923879564f);
                    }
                    break;

                case 100:
                    {
                        _arrowSprite.rotation = new Quaternion(0, 0, -0.707106829f, 0.707106829f);
                    }
                    break;
            }


            //_arrowSprite.rotation = new Quaternion(0, 0, -90f * Mathf.Deg2Rad, 0);

            //45 = Quaternion(0, 0, 0.382683426, 0.923879564);

            //90 = Quaternion(0, 0, 0.707106829, 0.707106829);

            ///0 = Quaternion(0, 0, 0, 1);

            //-90 = Quaternion(0, 0, -0.707106829, 0.707106829);

            //-45 = Quaternion(0, 0, -0.382683426, 0.923879564);

            
        }

        public void Confirm()
        {
            ShowClue(int.Parse(_answerField.GetComponent<InputField>().text));


        }

        public void ChangeFirstSwitch()
        {
            PullSwitch(1);
        }

        public void ChangeSecondSwitch()
        {
            if (_switch2.value == 0 || _switch2.value == 1) PullSwitch(2);
        }


        public void ChangeTirdSwitch()
        {
            PullSwitch(3);
        }

        public void PullSwitch(int input)
        {
            _keepAnswer[stage] = input;

            if (input == BaseOfRules(_meterCurrValue))
            {
                //_clueTxt.text = "Correct!";

                StageChange();
            }
            else
            {


                ResetStage();
            }


        }


        private void StageChange()
        {
            stage++;

            if (stage >= 4)
            {
                

                _clueTxt.text = "Component repair completed successfully!";

                _minigameMain.solved = true;

                //Destroy(this.gameObject);
            }
            else _clueTxt.text = null;

            _answerField.GetComponent<InputField>().text = null;


            SetMeter();
        }

        private void ResetStage()
        {
            stage = 0;

            _clueTxt.text = "Nope! Wrong switch!";

            SetMeter();

            _minigameMain.solved = false;
        }

        public void ShowClue(int input)
        {

            if (stage == 0)
            {
                switch (input)
                {
                    case 0:
                        {
                            _clueTxt.text = "Toggle second switch";
                        }
                        break;

                    case 25:
                        {
                            _clueTxt.text = "Toggle second switch";
                        }
                        break;


                    case 50:
                        {
                            _clueTxt.text = "Toggle first switch";
                        }
                        break;

                    case 75:
                        {
                            _clueTxt.text = "Toggle third switch";
                        }
                        break;

                    case 100:
                        {
                            _clueTxt.text = "Toggle first switch";
                        }
                        break;
                }
            }

            if (stage == 1)
            {
                switch (input)
                {
                    case 0:
                        {
                            _clueTxt.text = "Toggle third switch";
                        }
                        break;

                    case 25:
                        {
                            _clueTxt.text = "Toggle switch from 1st phase";
                        }
                        break;


                    case 50:
                        {
                            _clueTxt.text = "Toggle first switch";
                        }
                        break;

                    case 75:
                        {
                            _clueTxt.text = "Toggle switch from 1st phase";
                        }
                        break;

                    case 100:
                        {
                            _clueTxt.text = "Toggle second switch";
                        }
                        break;
                }
            }


            if (stage == 2)
            {
                switch (input)
                {
                    case 0:
                        {
                            _clueTxt.text = "Toggle switch from 2nd phase";
                        }
                        break;

                    case 25:
                        {
                            _clueTxt.text = "Toggle switch from 1st phase";
                        }
                        break;


                    case 50:
                        {
                            _clueTxt.text = "Toggle third switch";
                        }
                        break;

                    case 75:
                        {
                            _clueTxt.text = "Toggle second switch";
                        }
                        break;

                    case 100:
                        {
                            _clueTxt.text = "Toggle first switch";
                        }
                        break;
                }
            }

            if (stage == 3)
            {
                switch (input)
                {
                    case 0:
                        {
                            _clueTxt.text = "Toggle switch from 1st phase";
                        }
                        break;

                    case 25:
                        {
                            _clueTxt.text = "Toggle first switch";
                        }
                        break;


                    case 50:
                        {
                            _clueTxt.text = "Toggle switch from 2nd phase";
                        }
                        break;

                    case 75:
                        {
                            _clueTxt.text = "Toggle switch from 2nd phase";
                        }
                        break;

                    case 100:
                        {

                            _clueTxt.text = "Toggle switch from 3rd phase";
                        }
                        break;

                }
            }


            if (stage == 4)
            {
                switch (input)
                {
                    case 0:
                        {
                            _clueTxt.text = "Toggle switch from 1st phase";
                        }
                        break;

                    case 25:
                        {
                            _clueTxt.text = "Toggle switch from 2nd phase";
                        }
                        break;


                    case 50:
                        {
                            _clueTxt.text = "Toggle switch from 4th phase";
                        }
                        break;

                    case 75:
                        {
                            _clueTxt.text = "Toggle switch from 3rd phase";
                        }
                        break;

                    case 100:
                        {
                            _clueTxt.text = "Toggle switch from 2nd phase";
                        }
                        break;

                }
            }
        }





        public int BaseOfRules(int input)
        {



            if (stage == 0)
            {
                switch (input)
                {
                    case 0:
                        {
                            _correctSwitch = 2;

                        }
                        break;

                    case 25:
                        {
                            _correctSwitch = 2;

                        }
                        break;


                    case 50:
                        {
                            _correctSwitch = 1;

                        }
                        break;

                    case 75:
                        {
                            _correctSwitch = 3;

                        }
                        break;

                    case 100:
                        {
                            _correctSwitch = 1;

                        }
                        break;
                }
            }

            if (stage == 1)
            {
                switch (input)
                {
                    case 0:
                        {
                            _correctSwitch = 3;

                        }
                        break;

                    case 25:
                        {
                            _correctSwitch = _keepAnswer[0];

                        }
                        break;


                    case 50:
                        {
                            _correctSwitch = 1;

                        }
                        break;

                    case 75:
                        {
                            _correctSwitch = _keepAnswer[0];

                        }
                        break;

                    case 100:
                        {
                            _correctSwitch = 2;

                        }
                        break;
                }
            }


            if (stage == 2)
            {
                switch (input)
                {
                    case 0:
                        {
                            _correctSwitch = _keepAnswer[1];

                        }
                        break;

                    case 25:
                        {
                            _correctSwitch = _keepAnswer[0];

                        }
                        break;


                    case 50:
                        {
                            _correctSwitch = 3;

                        }
                        break;

                    case 75:
                        {
                            _correctSwitch = 2;

                        }
                        break;

                    case 100:
                        {
                            _correctSwitch = 1;

                        }
                        break;

                }
            }

            if (stage == 3)
            {
                switch (input)
                {
                    case 0:
                        {
                            _correctSwitch = _keepAnswer[0];

                        }
                        break;

                    case 25:
                        {
                            _correctSwitch = 1;

                        }
                        break;


                    case 50:
                        {
                            _correctSwitch = _keepAnswer[1];

                        }
                        break;

                    case 75:
                        {
                            _correctSwitch = _keepAnswer[1];

                        }
                        break;

                    case 100:
                        {
                            _correctSwitch = _keepAnswer[2];

                        }
                        break;


                }
            }


            if (stage == 4)
            {
                switch (input)
                {
                    case 0:
                        {
                            _correctSwitch = _keepAnswer[0];

                        }
                        break;

                    case 25:
                        {
                            _correctSwitch = _keepAnswer[1];

                        }
                        break;


                    case 50:
                        {
                            _correctSwitch = _keepAnswer[3];

                        }
                        break;

                    case 75:
                        {
                            _correctSwitch = _keepAnswer[2];

                        }
                        break;

                    case 100:
                        {
                            _correctSwitch = _keepAnswer[1];

                        }
                        break;


                }


            }

            return _correctSwitch;
        }
    }
}

