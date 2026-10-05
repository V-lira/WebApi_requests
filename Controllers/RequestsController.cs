using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication8.Data;
using WebApplication8.Models;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    public class RequestsController : Controller
    {
        // /Requests?status=New
        public ActionResult Index(RequestStatus? status)
        {
            var requests = AppData.Requests.AsEnumerable();

            if (status.HasValue)
                requests = requests.Where(r => r.Status == status.Value);

            return View(requests.OrderByDescending(r => r.CreatedAt).ToList());
        }

        // /Requests/Details/3
        public ActionResult Details(int id)
        {
            var request = AppData.Requests.FirstOrDefault(r => r.Id == id);
            if (request == null)
                return HttpNotFound();

            return View(request);
        }

        // /Requests/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // /Requests/Create
        [HttpPost]
        public ActionResult Create(RepairRequest request)
        {
            if (request == null)
                return HttpNotFound();
            request.Id = AppData.NextId();
            request.CreatedAt = DateTime.Now;
            request.Status = RequestStatus.New;

            AppData.Requests.Add(request);

            return RedirectToAction("Index");
        }

        // /Requests/ChangeStatus
        [HttpPost]
        public ActionResult ChangeStatus(int id, RequestStatus status)
        {
            var request = AppData.Requests.FirstOrDefault(r => r.Id == id);
            if (request == null)
                return HttpNotFound();

            request.Status = status;

            return RedirectToAction("Details", new { id = request.Id });
        }

        // /Requests/Statistics
        public ActionResult Statistics()
        {
            var vm = new StatisticsViewModel
            {
                Total = AppData.Requests.Count,
                New = AppData.Requests.Count(r => r.Status == RequestStatus.New),
                InProgress = AppData.Requests.Count(r => r.Status == RequestStatus.InProgress),
                Completed = AppData.Requests.Count(r => r.Status == RequestStatus.Completed),
                Cancelled = AppData.Requests.Count(r => r.Status == RequestStatus.Cancelled)
            };

            return View(vm);
        }
    }
}