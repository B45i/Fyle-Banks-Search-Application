using fyle_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fyle_backend.ServiceContracts
{
    public interface IBranchService
    {
        IList<BankBranches> GetBranchesByCity(string bankName, string city);
    }
}
