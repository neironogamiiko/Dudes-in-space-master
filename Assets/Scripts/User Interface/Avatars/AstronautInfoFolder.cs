using Crew.EventArgs;
using Star_Ship.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Star_Ship;

namespace User_Interface.Avatars
{
    public class AstronautInfoFolder : MonoBehaviour
    {
        [SerializeField] private Crew.Models.Crew _crew;
        [SerializeField] private TextMeshProUGUI _roleLabel;
        [SerializeField] private Image _roleSprite;
        [SerializeField] private GameObject _leftFolderConatiner;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _sanitySlider;
        [SerializeField] private Slider _phisycalSlider;
        [SerializeField] private Image _overallStatus;
        [SerializeField] private TextMeshProUGUI _overallStatusPercentsLabel;

        [SerializeField] private OverallShipStatus _shipStatus;

        private IAstronaut astronaut;
        private bool isAstroautSelected;

        private void Awake()
        {
            _crew.OnAstronautSelected += Crew_OnAstronautSelected;
        }

        private void Update()
        {
            if (isAstroautSelected) AstronautStatus();
        }

        private void Crew_OnAstronautSelected(object sender, CrewEventArgs args)
        {
            _roleLabel.SetText(args.Avatar.Role.ToString());
            _leftFolderConatiner.SetActive(true);
            astronaut = args.Avatar;
            _roleSprite.sprite = args.Avatar.PersonalInformation.astronautImage;

            isAstroautSelected = true;
        }

        private void AstronautStatus()
        {
            var health = astronaut.AstronautVitals.Health;
            _healthSlider.value = health * 0.01f;
            astronaut.AstronautVitals.TrySubstractHealth();

            var sanity = astronaut.AstronautVitals.Sanity;
            _sanitySlider.value = sanity * 0.01f;
            astronaut.AstronautVitals.TrySubstractSanity();

            var phisycal = astronaut.AstronautVitals.Phisycal;
            _phisycalSlider.value = phisycal * 0.01f;
            astronaut.AstronautVitals.TrySubstractPhysical();

            var overall = astronaut.AstronautVitals.Overall;
            _overallStatus.fillAmount = overall * 0.01f;
            _overallStatus.color = Color.Lerp(Color.red, Color.green, overall*0.01f);
            _overallStatusPercentsLabel.SetText($"{(int)astronaut.AstronautVitals.Overall}%");
        }
    }
}