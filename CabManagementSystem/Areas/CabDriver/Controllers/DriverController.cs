using Microsoft.AspNetCore.Mvc;

namespace CabManagementSystem.Areas.CabDriver.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
