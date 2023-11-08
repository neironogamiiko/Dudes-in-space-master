using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public class FactoryMedicTask : IFactory
    {
        public ITask Create()
        {
            ITask Medic = new MedicTask();
            return Medic;
        }
    }
}