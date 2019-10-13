using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fyle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchController : ControllerBase
    {
        private IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IList<BankBranches>> Get(
            [FromQuery] string bank,
            [FromQuery] string city,
            [FromQuery] int limit,
            [FromQuery] int offset)
        {
            return await _branchService.GetBranchesByCityAsync(bank, city, limit >= 0 ? limit : 15, offset >= 0 ? offset : 0);
        }

    }
}