using Travel2.Models;

namespace Travel2.Interfaces
{
    public interface IAgentRepository
    {
        void InsertAgent(Agent agent);
        void Save();
    }
}
