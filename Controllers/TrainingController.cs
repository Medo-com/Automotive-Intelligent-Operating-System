using Microsoft.AspNetCore.Mvc;

namespace AIOS.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult SalesSimulator()
        {
            return View("SalesSimulator");
        }
    }
}
