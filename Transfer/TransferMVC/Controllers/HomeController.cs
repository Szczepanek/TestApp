using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransferMVC.Models;

namespace TransferMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        public HomeController(ILogger<HomeController> logger, ITransferService transferService)
        {
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Initialize(int arrayLength)
        {
            return Json(_transferService.Initialize(arrayLength));
        }
        public JsonResult Transfer(int[] generatedNumbers)
        {
            return Json(_transferService.Transfer(generatedNumbers));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}