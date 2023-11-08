using UnityEngine;

namespace Astronaut.Interfaces
{
    public interface IPathfinder
    {
        void MoveToPosition(Vector3 position);
    }
}