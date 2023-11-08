using System;
using System.Collections;
using System.Collections.Generic;
using Collisions;
using Star_Ship.EventArgs;
using Star_Ship.Interfaces;
using Task_Generator.Tasks;
using UnityEngine;
using User_Interface;
using UnityEngine.UI;
using User_Interface.Tasks;

namespace Star_Ship
{
    public class ShipComponent : MonoBehaviour, IShipComponent, IShipComponentInformation
    {
        [SerializeField] private UnityEngine.Camera _camera;

        private static int _id;

        [SerializeField] private CollisionEvents _trigger;
        [SerializeField] private float _timeForBreakCycle = 3f;
        [SerializeField] private ShipComponentInformation _shipComponentInformation;

        public AudioSource alertAudio;
        public AudioClip alertSound;
        [SerializeField] private AudioClip _winSound;
        [SerializeField] private AudioClip _failSound;
        /// <summary>
        /// <param name="_healthSlider"> is image, that have slider functionality </param>
        /// </summary>
        [SerializeField] private Image _healthSlider;

        [SerializeField] private Slider _progressIndicator;

        private Vector3 _offset = new Vector3(0, 0, 0);

        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private GameObject _taskScreenPrefab;
        [SerializeField] private GameObject _taskScreen;

        private IAstronaut _astronaut;
        private int _currentId;
        
        private int _health = 100;
        private bool _isBeingFixed;
        private int _repairedTimes;
        private Coroutine _shipBreakCycle;
        private readonly Queue<ITask> _tasksToSolve = new Queue<ITask>();

        public float TaskSolvingProgress => TaskSolverTimer / GetCurrentTask().Time;


        private ShipComponentArgs ShipArgs =>
            new ShipComponentArgs(
                Health,
                IsInBreakCycle,
                GetCurrentTask());

        public int Health
        {
            get => _health;
            set
            {
                if (value < 0)
                    _gameOverScreen.SetupDead();
                // TODO : check this scenario
                _health = value;
            }
        }

        public bool IsInBreakCycle => _shipBreakCycle != null;
        public int TaskSolverTimer { set; get; }

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;

            _currentId = _id;
            _id++;
            _trigger.OnStartTrigger += OnInteractWithTrigger;

            
        }

        public event Action<object, ShipComponentArgs> OnShipComponentFixed;
        public event Action<object, ShipComponentArgs> OnShipComponentBroken;
        public event Action<object, ShipComponentArgs> OnShipComponentNotPossibleToFix;

        public Transform Transform => transform;

        public Roles RoleToSolve => GetCurrentTask()?.RoleToSolve ?? Roles.NONE;

        private void Update()
        {

            if (_shipComponentInformation._moduleType == ShipComponentInformation.ModuleType.Module)
            {
                if (Health <= 20 && !alertAudio.isPlaying) alertAudio.PlayOneShot(alertSound);


                _healthSlider.fillAmount = Health * 0.01f;


                _healthSlider.color = Color.Lerp(Color.red, Color.green, Health * 0.01f);


                if (Health < 100)
                {
                    //_progressIndicator.gameObject.SetActive(true);

                   // _progressIndicator.value = TaskSolverTimer;
                }
                
            }
        }

        public void AddTask(ITask Task)
        {
            

            _tasksToSolve.Enqueue(Task);

            TryToBreakComponent();


            

        }

        public void SetSlider(GameObject slider)
        {
            
        }

        public void RemoveTask()
        {
            _tasksToSolve.Dequeue();

            _healthSlider.fillAmount = 0;

            Destroy(_taskScreen);

        }

        public ITask GetCurrentTask()
        {
            if (_tasksToSolve.Count == 0)
                return null;

            return _tasksToSolve.Peek();
        }

        public void Interact(IAstronaut astronaut)
        {
            switch (_shipComponentInformation._moduleType)
            {
                case ShipComponentInformation.ModuleType.Module:
                    {
                        

                        if (_isBeingFixed) return;

                        _astronaut = astronaut;

                        

                        if (!IsPossibleToFix(astronaut) || !IsInBreakCycle)
                        {
                            OnShipComponentNotPossibleToFix?.Invoke(this, ShipArgs);

                           

                            _astronaut.IsOccupied = true;

                            StartCoroutine(FixCycle(astronaut.PersonalInformation._int, astronaut));
                            
                            return;
                        }
                        else
                        {
                            
                            //if (astronaut._dead == true) TryToBreakComponent();

                            StartCoroutine(FixCycle(astronaut.PersonalInformation._int / 2, astronaut));
                        }
                        

                        

                        
                    }
                    break;

                case ShipComponentInformation.ModuleType.MedicalBay:
                    StartCoroutine(Healing(astronaut));
                    //astronaut.AstronautVitals._health = 100;
                    astronaut.IsOccupied = true;
                    break;

                case ShipComponentInformation.ModuleType.Cabins:
                    StartCoroutine(Resting(astronaut));
                    //astronaut.AstronautVitals._sanity = 100;
                    astronaut.IsOccupied = true;
                    break;

                case ShipComponentInformation.ModuleType.Gym:
                    StartCoroutine(Training(astronaut));
                    //astronaut.AstronautVitals._phisycal = 100;
                    astronaut.IsOccupied = true;
                    break;
            }
            

        }

        private void SetupTaskScreen()
        {
            //if (_taskScreen != null) Destroy(_taskScreen);

            _taskScreen = Instantiate(_taskScreenPrefab, _gameOverScreen.transform.parent.GetChild(0).transform);

            _taskScreen.SetActive(true);

            _taskScreen.GetComponent<MinigameMain>().coundownSlider.maxValue = GetCurrentTask().Time;

            _taskScreen.GetComponent<MinigameMain>().coundownSlider.value = _taskScreen.GetComponent<MinigameMain>().coundownSlider.maxValue;
        }

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
        }

        public int CountTasks()
        {
            return _tasksToSolve.Count;
        }

        public ShipComponentInformation ComponentInformation => _shipComponentInformation;

        private void TryToBreakComponent()
        {
            _shipBreakCycle = StartCoroutine(BreakCycle());
        }

        private IEnumerator FixCycle(int solvingSpeed, IAstronaut astronaut)
        {

            _astronaut.IsOccupied = true;

            _isBeingFixed = true;

            SetupTaskScreen();

            while (TaskSolvingProgress <= 1f && _astronaut.IsOccupied == true)
            {
                TaskSolverTimer++;

                _taskScreen.GetComponentInChildren<Slider>().value -= 1;

                yield return new WaitForSeconds(1);
            }

            /*
            if (_taskScreen.GetComponentInChildren<TaskWires>().solveTimer.value <= 0)
            {
                _taskScreen.GetComponentInChildren<TaskWires>().CloseMenu();

                //SetupTaskScreen();

                yield return null;
            }*/

            if (_astronaut.IsOccupied == true && _taskScreen.GetComponent<MinigameMain>().solved == true) TryFixShipComponent();
            else 
            {
                
                _isBeingFixed = false;

                while (TaskSolverTimer > 0 && _astronaut.IsOccupied == false)
                {
                    TaskSolverTimer--;

                    yield return new WaitForSeconds(1);
                }
            }
        }

        private IEnumerator BreakCycle()
        {
            OnShipComponentBroken?.Invoke(this, new ShipComponentArgs(Health, IsInBreakCycle, GetCurrentTask()));

            while (true)
            {
                if (Health <= 0 && IsInBreakCycle) break;
                Health -= 1;

                yield return new WaitForSeconds(_timeForBreakCycle);
            }
        }

        private bool TryFixShipComponent()
        {
            if (!IsInBreakCycle)
            {
                // TODO : replace with it's own arguments and rewrite event (for signalizing player about it) 
                OnShipComponentNotPossibleToFix?.Invoke(this,
                    new ShipComponentArgs(Health, IsInBreakCycle, GetCurrentTask()));
                return false;
            }
            
            alertAudio.PlayOneShot(_winSound);
            StopCoroutine(_shipBreakCycle);
            OnShipComponentFixed?.Invoke(this, new ShipComponentArgs(Health, IsInBreakCycle, GetCurrentTask()));
            Health = 100;
            TaskSolverTimer = 0;
            _repairedTimes++;
           
            _isBeingFixed = false;
            _astronaut.IsOccupied = false;

            RemoveTask();
            return true;
        }

        protected virtual bool IsPossibleToFix(IAstronaut astronaut)
        {
            var isAstronaut = astronaut is Astronaut.Astronaut;
            if (!isAstronaut) return false;
            return astronaut.Role == RoleToSolve;
        }
        
        private IEnumerator Healing(IAstronaut astronaut)
        {
            while (astronaut.IsOccupied = true && astronaut.AstronautVitals._health < 100)
            {
                astronaut.AstronautVitals._health += 10;

                yield return new WaitForSeconds(1);
            }

        }

        private IEnumerator Resting(IAstronaut astronaut)
        {
            while (astronaut.IsOccupied = true && astronaut.AstronautVitals._sanity < 100)
            {
                astronaut.AstronautVitals._sanity += 10;

                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerator Training(IAstronaut astronaut)
        {
            while (astronaut.IsOccupied = true && astronaut.AstronautVitals._phisycal < 100)
            {
                astronaut.AstronautVitals._phisycal += 10;

                yield return new WaitForSeconds(1);
            }
        }

        /// <summary>
        ///     Method is called whenever something interacts with ship component.
        /// </summary>
        /// <param name="passedGameObject"> Object that interacted with this ship component. </param>
        public void OnInteractWithTrigger(GameObject passedGameObject)
        {
            if (passedGameObject.TryGetComponent(out IAstronaut cosmonaut)) Interact(cosmonaut);

        }


        public override string ToString()
        {
            return $"Ship: health: {Health}; isInBreakCycle = {IsInBreakCycle   }";
        }
    }
}
