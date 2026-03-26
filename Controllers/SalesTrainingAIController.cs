using AIOS.Models;
using AIOS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AIOS.Controllers.API
{
    [ApiController]
    [Route("api/ai/sales-simulator")]
    public class SalesTrainingAIController : ControllerBase
    {
        private readonly SalesTrainingRepository _repo;

        public SalesTrainingAIController(SalesTrainingRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Simulate([FromBody] SalesTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var result = _repo.GetReply(request);
            return Ok(result);
        }
    }
}
