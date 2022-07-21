using System.Diagnostics;
using SegundoParcial.Models;
using SegundoParcial.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace SegundoParcial.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> objEventList = _unitOfWork.Event.GetAll();
            return View(objEventList);
        }

        public IActionResult Detail(int? id)
        {

            Event newEvent = new();


            if (id == null || id <= 0)
            {
                return View(newEvent);
            }
            else
            {
                newEvent = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == id);
                return View(newEvent);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}