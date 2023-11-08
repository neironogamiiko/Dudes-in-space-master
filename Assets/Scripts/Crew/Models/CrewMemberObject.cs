using Star_Ship;
using UnityEngine;

namespace Crew.Models
{
    [CreateAssetMenu(fileName = "CrewMember", menuName = "ScriptableObjects/CrewMember", order = 0)]
    public class CrewMemberObject : ScriptableObject
    {
        public Roles _astronautRole;
        public string _name;
        public int _age;
        public int _int = 3;
        public int _psc = 3;
        public Sprite astronautImage;
    }
}