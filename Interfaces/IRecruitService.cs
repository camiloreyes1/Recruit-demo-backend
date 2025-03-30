using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruits.api.Models;

namespace Recruits.api.Interfaces
{
    public interface IRecruitService
    {
        // Method to search for recruits based on a query string
        Task<IEnumerable<Recruit>> SeachRecruitsAsync(string query);

        //Method to add a new recruit to the Elastic DB
        Task AddRecruitAsync(Recruit recruit);
        
    }
}