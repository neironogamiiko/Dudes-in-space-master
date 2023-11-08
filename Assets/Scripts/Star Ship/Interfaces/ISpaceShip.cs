using Task_Generator.EventArgs;
using Task_Generator.Models;

namespace Star_Ship.Interfaces
{
    public interface ISpaceShip
    {
        void OnTaskGenerated(object sender, TaskEventArgs args);
        void SetTaskAsigner(TaskAsigner asigner);
    }
}