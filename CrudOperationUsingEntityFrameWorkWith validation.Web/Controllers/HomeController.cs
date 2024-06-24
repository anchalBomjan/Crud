using CrudOperationUsingEntityFrameWorkWith_validation.Web.Data;
using CrudOperationUsingEntityFrameWorkWith_validation.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudOperationUsingEntityFrameWorkWith_validation.Web.Controllers
{
    public class HomeController : Controller
    {

        private SchoolContext schoolContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SchoolContext sc)
        {
            _logger = logger;
            schoolContext = sc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                schoolContext.Teachers.Add(teacher);
                schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
