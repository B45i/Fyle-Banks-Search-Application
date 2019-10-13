using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fyle_backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/Bank/5
        [HttpGet("{ifsc}", Name = "Get")]

        public BankBranches Get(string ifsc)
        {
            return _bankService.GetBankDetails(ifsc);
        }

    }
}
