using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Travel2.Interfaces;
using Travel2.Models;

namespace Travel2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgenciesController : Controller
    {
        private IAgencyRepository _agencyRepository;
        public AgenciesController(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }

        [HttpGet]
        public ActionResult GetAllAgencies()
        {
            List<Agency> agencies = _agencyRepository.GetAllAgencies();
            return Ok(agencies);
        }

        [HttpGet("{id}")]
        public ActionResult GetAgency(Int32 id)
        {
            Agency agency = _agencyRepository.GetAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            return Ok(agency);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAgency(int id, [FromForm] Agency agency)
        {
            if (id != agency.Id)
            {
                return BadRequest();
            }            
            try
            {
                _agencyRepository.UpdateAgency(agency);
                _agencyRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyExists(agency.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Agency> CreateAgency([FromForm] Agency agency)
        {
            _agencyRepository.InsertAgency(agency); 
            _agencyRepository.Save(); 

            return CreatedAtAction("GetAngency", new { id = agency.Id }, agency);
        }

        [HttpPut("{id}")]
        public IActionResult AddAgentToAgency(int agencyId, [FromForm] Agent agent)
        {
            Agency agency = _agencyRepository.GetAgency(agencyId);
            if (agency == null)
            {
                return NotFound();
            }
            try
            {
                _agencyRepository.AddAgentToAgency(agencyId, agent);
                _agencyRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyExists(agencyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private Boolean AgencyExists(Int32 id)
        {
            return _agencyRepository.GetAgency(id) != null;
        }
    }
}
