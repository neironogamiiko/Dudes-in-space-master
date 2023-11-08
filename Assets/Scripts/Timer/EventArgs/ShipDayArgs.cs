namespace Timer.EventArgs
{
    public class ShipDayArgs : System.EventArgs
    {
        public ShipDayArgs(bool isSpecial, int days)
        {
            IsSpecial = isSpecial;
            Days = days;
        }

        public int Days { get; }

        public bool IsSpecial { get; }
    }
}