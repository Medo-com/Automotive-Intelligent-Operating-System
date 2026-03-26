using AIOS.Models;
using AIOS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AIOS.Controllers.API
{
    [ApiController]
    [Route("api/ai/loan-approval")]
    public class LoanApprovalAIController : ControllerBase
    {
        private readonly LoanApprovalRepository _repo;

        public LoanApprovalAIController(LoanApprovalRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult PredictApproval([FromBody] LoanApprovalRequest req)
        {
            if (req == null)
                return BadRequest();

            var result = _repo.CalculateApproval(req);
            return Ok(result);
        }
    }
}
