using Microsoft.AspNetCore.Mvc;
using SegundoParcial.Models;
using SegundoParcial.Repository.IRepository;

namespace SegundoParcial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public EventController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index()
        {
            IEnumerable<Event> objEventList = _unitOfWork.Event.GetAll();
            return View(objEventList);
        }


        //GET
        public IActionResult Upsert(int? id)
        {

            Event Event = new();

            if (id == null || id <= 0)
            {
                return View(Event);
            }
            else
            {
                Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == id);
                return View(Event);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Event obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\events");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.ImageUrl != null)
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, obj.ImageUrl);
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.ImageUrl = @"images\events\" + fileName + extension;
                }

                if (obj.Id == 0)
                {
                    _unitOfWork.Event.Add(obj);
                }
                else
                {
                    _unitOfWork.Event.Update(obj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Event updated successfully";
            }
            return RedirectToAction("Index");
        }


        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var eventList = _unitOfWork.Event.GetAll();
            return Json(new { data = eventList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Event.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error at deleting" });

            var oldImageUrl = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl);
            if (System.IO.File.Exists(oldImageUrl))
            {
                System.IO.File.Delete(oldImageUrl);
            }

            _unitOfWork.Event.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Event deleted successfully" });
        }
        #endregion

    }
}

