using JetBrains.Annotations;
using Task_Generator.Tasks;

namespace Star_Ship.EventArgs
{
    public class ShipComponentArgs : System.EventArgs
    {
        public ShipComponentArgs(int shipHealth, bool isInBreakCycle, [CanBeNull] ITask task)
        {
            ShipHealth = shipHealth;
            IsInBreakCycle = isInBreakCycle;
            Task = task;
        }

        public int ShipHealth { get; }
        public bool IsInBreakCycle { get; }
        [CanBeNull] public ITask Task { get; }

        public override string ToString()
        {
            return $"shipHealth: {ShipHealth}; isInBreak: {IsInBreakCycle}";
        }
    }
}