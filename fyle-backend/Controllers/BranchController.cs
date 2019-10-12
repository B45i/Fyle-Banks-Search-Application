using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace fyle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public IList<BankBranches> Get([FromQuery] string bank, [FromQuery] string city)
        {
            return _branchService.GetBranchesByCity(bank, city);
        }

    }
}