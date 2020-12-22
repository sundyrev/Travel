using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel2.Models;

namespace Travel2.Interfaces
{
    public interface IAgencyRepository
    {
        List<Agency> GetAllAgencies();
        Agency GetAgency(int agencyId);
        void InsertAgency(Agency agency);
        void DeleteAgency(int agencyId);
        void UpdateAgency(Agency agency);
        void AddAgentToAgency(int AgencyId, Agent agent);
        void Save();
    }
}
