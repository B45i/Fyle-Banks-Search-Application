using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using System;
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
        public IList<BankBranches> GetBranchesByCity(string bankName, string city)
        {
            return _dbContext.BankBranches.Where(
                x => x.BankName.ToLower() == bankName.ToLower() && 
                x.City.ToLower() == city.ToLower()).ToList();
        }
    }
}
