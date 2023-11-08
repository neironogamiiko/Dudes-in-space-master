using UnityEngine;
using Crew.Models;

namespace Astronaut
{
    public class AstronautVitals
    {
        public float K1; // коэфициент влияния показателей здоровья.
        public float K2; // коэфициент влияния состояния корабля.
        public float K3; // коэфициент уменьшения показателей.
        public float _health = 100; // показатель здоровья.
        public float _phisycal = 100; // показатель физ. формы.
        public float _sanity = 100; // показатель рассудка. (свойство)
        public bool _dead;
        private Astronaut _astronaut;

        public float Sanity
        {
            get => _sanity;
            set
            {
                if (value < 0 && value > 100) return;
                _sanity = value;
            }
        }

        public float Health
        {
            get => _health;
            set
            {
                if (value < 0 && value > 100) return;
                _health = value;
            }
        }

        public float Phisycal
        {
            get => _phisycal;
            set
            {
                if (value < 0 && value > 100) return;
                _phisycal = value;
            }
        }

        public float Overall => Mathf.Clamp((Sanity + Phisycal + Health) / 3, 0, 100); // мат. апарат для розрахунку за показника стану астронавта.

        public CrewMemberObject PersonalInformation { get; }


        public bool TrySubstractSanity() // на место shipstatus будет передаваться _shipstatus из условного класса Ship.
        {
            Sanity -= Mathf.Clamp(K1 * Time.deltaTime, 0, 100); // мат. аппарат для расчёта показателя рассудка.
            return true;
        }

        public bool TrySubstractHealth() // на место shipstatus будет передаваться _shipstatus из условного класса Ship.
        {
            Health -= Mathf.Clamp(K2 * Time.deltaTime, 0, 100); // мат. аппарат для расчёта показателей здоровья.
            return true;
        }

        public bool TrySubstractPhysical()
        {
            Phisycal -= Mathf.Clamp(K3 * Time.deltaTime, 0, 100); // мат. аппарат для расчёта показателей физ. формы.
            return true;
        }
    }
}