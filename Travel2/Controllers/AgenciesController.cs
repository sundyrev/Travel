using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
             List < Agency> agencies = _agencyRepository.GetAllAgencies();
            return Ok(agencies);
        }

        [HttpGet("{id}")]
        public ActionResult GetAgency(int id)
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
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyExists(agency.Id))
                {
                    return NotFound();
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
            catch (SqlException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    switch (sqlException.Number)
                    {
                        case 2627:  // Unique constraint error
                            break;
                        case 547:   // Constraint check violation
                            break;
                        case 2601:  // Duplicated key row error
                            break;
                        default:
                            throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Agency> CreateAgency([FromForm] Agency agency)
        {
            _agencyRepository.InsertAgency(agency); 

            return Ok(agency);
        }

        [HttpPut("{id}")]
        public IActionResult AddAgentToAgency(int id, [FromForm] Agent agent)
        {
            Agency agency = _agencyRepository.GetAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            try
            {
                _agencyRepository.AddAgentToAgency(id, agent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (agency == null)
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

        private bool AgencyExists(int id)
        {
            return _agencyRepository.GetAgency(id) != null;
        }
    }
}
