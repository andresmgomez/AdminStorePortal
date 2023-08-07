using Microsoft.AspNetCore.Mvc;

namespace StoreSolution.Web.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
