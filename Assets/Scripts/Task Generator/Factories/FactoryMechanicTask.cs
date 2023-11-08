using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class FactoryMechanicTask : IFactory
    {
        public ITask Create()
        {
            ITask Mechanic = new MechanicTask();
            return Mechanic;
        }
    }
}