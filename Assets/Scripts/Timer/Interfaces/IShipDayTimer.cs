using System;
using Timer.EventArgs;

namespace Timer.Interfaces
{
    public interface IShipDayTimer
    {
        /// <summary>
        ///     Event that must be triggered when new day begins.
        /// </summary>
        public event Action<object, ShipDayArgs> OnNewDayStarted;

        /// <summary>
        ///     Event that must be triggered when day is ended.
        /// </summary>
        public event Action<object, ShipDayArgs> OnDayEnded;
    }
}