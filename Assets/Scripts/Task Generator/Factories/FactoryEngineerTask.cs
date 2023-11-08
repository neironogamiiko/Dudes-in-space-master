using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class FactoryEngineerTask : IFactory
    {
        public ITask Create()
        {
            ITask Engineer = new EngineerTask();
            return Engineer;
        }
    }
}