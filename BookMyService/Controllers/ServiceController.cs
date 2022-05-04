using BookMyService.Data;
using BookMyService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookMyService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("username");
            var data = _context.RegisterUser.Where(x => x.UserName == username).ToList();
            if (data.FirstOrDefault().Approve == "Verified")
            {
                var data12 = _context.Services.Where(x => x.ProviderDetail == username).ToList();
                return View(data12);

            }
            else
            {
                return RedirectToAction("Index", "Seeker");
            }


        }
        public IActionResult CreateServices()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateServices(Service service)
        {
            var username = HttpContext.Session.GetString("username");
            var servicedate = new Service();
            servicedate.StartDate = service.StartDate;
            servicedate.Name = service.Name;
            servicedate.Category = service.Category;
            servicedate.FinishDate = service.FinishDate;
            servicedate.StartDate = DateTime.Now;
            servicedate.ProviderDetail = username;
            _context.Services.Add(servicedate);
            _context.SaveChanges();
            return RedirectToAction("Index", "Service");
        }
    }
}
