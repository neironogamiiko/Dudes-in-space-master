using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class FactoryShturmanTask : IFactory
    {
        public ITask Create()
        {
            ITask Shturman = new ShturmanTask();
            return Shturman;
        }
    }
}