using System.Collections.Generic;
using Crew.EventArgs;
using UnityEngine;
using UnityEngine.UI;

namespace User_Interface.Avatars
{
    public class AvatarsBar : MonoBehaviour
    {
        [SerializeField] private Crew.Models.Crew _crew;
        [SerializeField] private GameObject _avatarBarButton;

        private List<Image> avatarsStatus;


        private void Awake()
        {
            _crew.OnCrewLoaded += OnCrewLoaded;

            avatarsStatus = new List<Image>(); // () - конструктор by defolt
        }

        private void Update()
        {
            var crewList = _crew.CrewAvatasList;
            for (var i = 0; i < avatarsStatus.Count; i++)
            {
                var overall = (crewList[i] as Astronaut.Astronaut).AstronautVitals.Overall;
                avatarsStatus[i].fillAmount = overall*0.01f;
                avatarsStatus[i].color = Color.Lerp(Color.red, Color.green, overall*0.01f);
            }
        }

        private void OnCrewLoaded(object sender, CrewDataEventArgs args)
        {
            for (var i = 0; i < args.CrewMemberObjects.Count; i++)
            {
                var obj = args.CrewMemberObjects[i];
                var button = Instantiate(_avatarBarButton, transform);
                var j = i;
                button.GetComponent<Button>().onClick.AddListener(delegate { _crew.SelectAstronaut(j); });
                button.transform.GetChild(1).GetComponent<Image>().sprite = obj.astronautImage;
                avatarsStatus.Add(button.transform.GetChild(3).GetComponent<Image>()); 
            }
        }


    }
}