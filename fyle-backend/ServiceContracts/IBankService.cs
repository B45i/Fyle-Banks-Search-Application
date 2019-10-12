using fyle_backend.Models;

namespace fyle_backend.ServiceContracts
{
    public interface IBankService
    {
        public BankBranches GetBankDetails(string ifsc);
    }
}
