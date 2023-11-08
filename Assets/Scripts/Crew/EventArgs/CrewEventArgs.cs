using Star_Ship.Interfaces;

namespace Crew.EventArgs
{
    public class CrewEventArgs : System.EventArgs
    {
        public CrewEventArgs(IAstronaut astro)
        {
            Avatar = astro;
        }

        public IAstronaut Avatar { get; }
    }
}