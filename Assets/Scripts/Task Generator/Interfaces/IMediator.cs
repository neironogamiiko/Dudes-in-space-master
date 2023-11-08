using Task_Generator.Models;

namespace Task_Generator.Interfaces
{
    public interface IMediator
    {
        /// <summary>
        ///     Method that notifies requested object in arguments.
        /// </summary>
        /// <param name="sender"> Object requested communication. </param>
        /// <param name="args"> Arguments that specify which object is to communicate with. </param>
        void Notify(Component sender, System.EventArgs args);
    }
}