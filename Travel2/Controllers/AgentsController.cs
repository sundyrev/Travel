using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Travel2.Interfaces;
using Travel2.Models;

namespace Travel2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : Controller
    {
        private IAgentRepository _agentRepository;

        public AgentsController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpPost]
        public ActionResult<Agent> CreateAgent(Agent agent)
        {
            _agentRepository.InsertAgent(agent);
            _agentRepository.Save();

            return CreatedAtAction("GetAgent", new { id = agent.Id }, agent);
        }
    }
}
