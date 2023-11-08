using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class FactoryScientistTask : IFactory
    {
        public ITask Create()
        {
            ITask Scientist = new ScientistTask();
            return Scientist;
        }
    }
}