using Microsoft.AspNetCore.Mvc;
using Travel2.Interfaces;
using Travel2.Models;

namespace Travel2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgentsController : Controller
    {
        private IAgentRepository _agentRepository;

        public AgentsController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpPost]
        public ActionResult<Agent> CreateAgent([FromForm] Agent agent)
        {
            _agentRepository.InsertAgent(agent);

            return Ok(agent);   
        }
    }
}
