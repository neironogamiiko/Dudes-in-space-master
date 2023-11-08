using System;
using System.Collections.Generic;
using Crew.EventArgs;
using Star_Ship.EventArgs;
using Star_Ship.Interfaces;
using UnityEngine;
using User_Interface.Markers;
using Random = UnityEngine.Random;
using User_Interface;
using Astronaut.Interfaces;

namespace Crew.Models
{
    public class Crew : MonoBehaviour
    {
        [SerializeField] private List<CrewMemberObject> _crewMembersList;
        [SerializeField] private MarkersCollection _markers;
        public GameOverScreen _gameOverScreen;
        private UnityEngine.Camera cam;
        private List<Transform> _astronautPrefab;
        private IAstronaut _selectedAstronaut;

        public List<IAstronaut> CrewAvatasList { get; private set; }

        private void Awake()
        {
            if (_markers) _markers.OnMarkerSelected += _markers_OnMarkerSelected;
            _astronautPrefab = new List<Transform>();
            for (var i = 0; i < 5; i++)
            {
                _astronautPrefab.Add(Resources.Load<Transform>($"Prefabs/Astronaut{i}"));
            }
            StartCoroutine(LoadAstronauts());

            cam = UnityEngine.Camera.main;
        }

        public event Action<object, CrewEventArgs> OnAstronautSelected;
        public event Action<object, CrewEventArgs> OnAstronautSpawned;
        public event Action<object, CrewDataEventArgs> OnCrewLoaded;

        private void _markers_OnMarkerSelected(object sender, RoomMarkerEventArgs args)
        {
            if (_selectedAstronaut == null)
                return;

            _selectedAstronaut.Move(args.ResponsibleComponent);
        }

        private void LoadValuesIntoAstronaut(CrewMemberObject info, IAstronaut astronaut)
        {
            astronaut.PersonalInformation = info;
            astronaut.Role = info._astronautRole;
        }

        private IEnumerator<WaitForSeconds> LoadAstronauts()
        {
            yield return new WaitForSeconds(0f);
            CrewAvatasList = new List<IAstronaut>();
            foreach (var obj in _crewMembersList)
            {
                var astronautTransform = Instantiate(_astronautPrefab[CrewAvatasList.Count],
                    transform.position + Vector3.left * CrewAvatasList.Count, Quaternion.identity, transform); // Random.Range(-5, 5) <- CrewAvatasList.Count
                
                // TODO restore vitals from saving system.
                var astronaut = astronautTransform.GetComponent<IAstronaut>();
                LoadValuesIntoAstronaut(obj, astronaut);
                astronautTransform.name = astronaut.PersonalInformation._astronautRole.ToString();
                CrewAvatasList.Add(astronaut);
                OnAstronautSpawned?.Invoke(this, new CrewEventArgs(astronaut));
            }

            OnCrewLoaded?.Invoke(this, new CrewDataEventArgs(_crewMembersList));
            yield return new WaitForSeconds(1f);
        }

        public void SelectAstronaut(int id)
        {
            if (id < 0 || id > CrewAvatasList.Count - 1)
                throw new IndexOutOfRangeException("Crew -> Crew Awatars List");

            
            _selectedAstronaut = CrewAvatasList[id];

            cam.transform.position = new Vector3 (transform.GetChild(id).gameObject.transform.position.x - 15, cam.transform.position.y, transform.GetChild(id).gameObject.transform.position.z - 15);
            OnAstronautSelected?.Invoke(this, new CrewEventArgs(_selectedAstronaut));
        }
    }
}