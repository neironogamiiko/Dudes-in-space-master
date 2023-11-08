using Astronaut;
using Crew.Models;

namespace Star_Ship.Interfaces
{
    public interface IAstronaut
    {
        

        /// <summary>
        ///     Responsible for storing personal astronaut information like
        ///     <see cref="CrewMemberObject._name" />, <see cref="CrewMemberObject._age" />,
        ///     <see cref="CrewMemberObject._astronautRole" />, etc.
        /// </summary>
        CrewMemberObject PersonalInformation { get; set; }

        /// <summary>
        ///     This property is responsible for storing vital astronaut's values (health, physical activity and sanity).
        /// </summary>
        AstronautVitals AstronautVitals { get; }

        /// <summary>
        ///     Tells astronaut's <see cref="Roles" />.
        /// </summary>
        Roles Role { get; set; }

        /// <summary>
        ///     Tells whether astronaut is busy or not.
        /// </summary>
        bool IsOccupied { get; set; }

        bool _dead { get; }

        /// <summary>
        ///     Moves astronaut to a specific module.
        ///     Module passed in <paramref name="component" /> must implement <see cref="IShipComponent" />.
        /// </summary>
        void Move(IShipComponent component);
    }
}