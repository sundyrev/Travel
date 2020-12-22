﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel2.Controllers;
using Travel2.Interfaces;
using Travel2.Models;

namespace Travel2.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AgencyDbContext _context;
        private bool disposed = false;

        public AgencyRepository(AgencyDbContext context)
        {
            _context = context;
        }

        public List<Agency> GetAllAgencies()
        {
            return _context.Agencies.Include(c => c.Agents).ToList();
        }
        public Agency GetAgency(int agencyId)
        {
            return _context.Agencies.Find(agencyId);
        }

        public void InsertAgency(Agency agency)
        {
            _context.Agencies.Add(agency);
        }

        public void DeleteAgency(int agencyId)
        {
            Agency agency = _context.Agencies.Find(agencyId);
            _context.Agencies.Remove(agency);
        }

        public void UpdateAgency(Agency agency)
        {
            _context.Entry(agency).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddAgentToAgency(int agencyId, Agent agent)
        {
            var agency = GetAgency(agencyId);
            if (!agency.Agents.Any(_ => _.Id == agent.Id)) 
            {
                agency.Agents.Add(agent);
                _context.Entry(agency).State = EntityState.Modified;
            }
        }
    }
}