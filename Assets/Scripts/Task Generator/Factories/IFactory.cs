using Task_Generator.Tasks;

namespace Task_Generator.Factories
{
    public interface IFactory
    {
        ITask Create();
    }
}