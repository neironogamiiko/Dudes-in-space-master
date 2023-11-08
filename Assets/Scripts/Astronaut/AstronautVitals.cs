using UnityEngine;
using Crew.Models;

namespace Astronaut
{
    public class AstronautVitals
    {
        public float K1; // ���������� ������� ����������� ��������.
        public float K2; // ���������� ������� ��������� �������.
        public float K3; // ���������� ���������� �����������.
        public float _health = 100; // ���������� ��������.
        public float _phisycal = 100; // ���������� ���. �����.
        public float _sanity = 100; // ���������� ��������. (��������)
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

        public float Overall => Mathf.Clamp((Sanity + Phisycal + Health) / 3, 0, 100); // ���. ������ ��� ���������� �� ��������� ����� ����������.

        public CrewMemberObject PersonalInformation { get; }


        public bool TrySubstractSanity() // �� ����� shipstatus ����� ������������ _shipstatus �� ��������� ������ Ship.
        {
            Sanity -= Mathf.Clamp(K1 * Time.deltaTime, 0, 100); // ���. ������� ��� ������� ���������� ��������.
            return true;
        }

        public bool TrySubstractHealth() // �� ����� shipstatus ����� ������������ _shipstatus �� ��������� ������ Ship.
        {
            Health -= Mathf.Clamp(K2 * Time.deltaTime, 0, 100); // ���. ������� ��� ������� ����������� ��������.
            return true;
        }

        public bool TrySubstractPhysical()
        {
            Phisycal -= Mathf.Clamp(K3 * Time.deltaTime, 0, 100); // ���. ������� ��� ������� ����������� ���. �����.
            return true;
        }
    }
}