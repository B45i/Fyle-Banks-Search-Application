﻿using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fyle_backend.Services
{
    public class BranchService : IBranchService
    {
        private postgresContext _dbContext;

        public BranchService(postgresContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<BankBranches>> GetBranchesByCityAsync(string bankName, string city, int limit, int offset)
        {
            return await _dbContext.BankBranches.Where(
                x => x.BankName.ToLower() == bankName.ToLower() && 
                x.City.ToLower() == city.ToLower())
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }
    }
}
