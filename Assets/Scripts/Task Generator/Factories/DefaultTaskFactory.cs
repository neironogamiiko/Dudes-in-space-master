using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class DefaultTaskFactory : IFactory
    {
        public ITask Create()
        {
            return new DefaultTask();
        }
    }
}