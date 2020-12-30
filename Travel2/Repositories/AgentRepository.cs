using Travel2.Controllers;
using Travel2.Interfaces;
using Travel2.Models;

namespace Travel2.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private AgencyDbContext _context;
        public AgentRepository(AgencyDbContext context)
        {
            _context = context;
        }

        public void InsertAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }
    }
}
