using fyle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fyle_backend.ServiceContracts
{
    public interface IBranchService
    {
        Task<IList<BankBranches>> GetBranchesByCityAsync(string bankName, string city, int limit, int offset);
    }
}
