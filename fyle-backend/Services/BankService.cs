using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fyle_backend.Services
{
    public class BankService : IBankService
    {
        private postgresContext _dbContext;
        public BankService(postgresContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BankBranches GetBankDetails(string ifsc)
        {
            return _dbContext.BankBranches.FirstOrDefault(x => x.Ifsc == ifsc);
        }
    }
}
