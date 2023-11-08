using Task_Generator.Interfaces;

namespace Task_Generator.Models
{
    public class Component
    {
        protected IMediator _dialog;

        public Component(IMediator dialog)
        {
            _dialog = dialog;
        }

        public void Ping()
        {
            // TIP : sends information about event that's done 
            _dialog.Notify(this, System.EventArgs.Empty);
        }
    }
}